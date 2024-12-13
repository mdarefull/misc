using CommonStore.Models.Pcl;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeMap.Business.Services
{
    public class HomeServices : IHomeServices
    {
        private readonly IRepository<Topic, long> _topicsRepository;
        private readonly IRepository<Reference, long> _referencesRepository;
        public HomeServices(IRepository<Topic, long> topicsRepository, IRepository<Reference, long> referencesRepository)
        {
            _topicsRepository = topicsRepository;
            _referencesRepository = referencesRepository;
        }

        public virtual Topic GetTopic(long id)
        {
            var topic = _topicsRepository.GetById(id);
            if (topic != null)
            {
                topic.SubTopics = topic.SubTopics.OrderBy(s => s.Name).ThenBy(s => s.Id).ToList();
                topic.References = topic.References.OrderBy(r => r.Name).ThenBy(r => r.Id).ToList();
            }

            return topic;
        }

        public virtual Reference RemoveReference(long id)
        {
            return _referencesRepository.RemoveAtomic(id);
        }

        public virtual Reference AddReference(long topicId, Reference newReference)
        {
            if (newReference == null)
                throw new ArgumentException("Reference argument cannot be null.");

            var topic = _topicsRepository.GetById(topicId);
            if (topic == null)
                return null;

            topic.References.Add(newReference);
            _topicsRepository.SaveChanges();
            return newReference;
        }

        public virtual Topic RemoveTopic(long id, bool keepSubtopics = false, bool keepReferences = false)
        {
            if (IsUniverseTopic(id))
                throw new ArgumentException("The Universe topic cannot be removed.");

            var topic = _topicsRepository.GetById(id);
            if (topic == null)
                return null;

            topic = RemoveTopic(topic, keepSubtopics, keepReferences);
            _topicsRepository.SaveChanges();
            return topic;
        }
        protected virtual Topic RemoveTopic(Topic topic, bool keepSubtopics, bool keepReferences)
        {
            var subTopics = topic.SubTopics.ToList();
            topic.SubTopics.Clear();
            if (keepSubtopics)
            {
                foreach (var subTopic in subTopics)
                    subTopic.Owner = topic.Owner;
                topic.Owner.SubTopics.AddRange(subTopics);
            }
            else
                foreach (var subTopic in subTopics)
                    RemoveTopic(subTopic, false, false);

            var references = topic.References.ToList();
            topic.References.Clear();
            if (keepReferences)
                foreach (var reference in references)
                    ChangeReferenceOwner(topic, topic.Owner, reference);
            else
            {
                foreach (var reference in references)
                    _referencesRepository.Remove(reference.Id);
            }

            var topicOwner = topic.Owner;
            topic = _topicsRepository.Remove(topic.Id);
            return topic == null ? null : topicOwner;
        }

        public virtual Reference ChangeReferenceOwner(long currentOwnerId, long refId, long nextOwnerId)
        {
            var currentOwner = _topicsRepository.GetById(currentOwnerId);
            if (currentOwner == null)
                return null;

            var reference = currentOwner.References.FirstOrDefault(r => r.Id == refId);
            if (reference == null)
                return null;

            var nextOwner = _topicsRepository.GetById(nextOwnerId);
            if (nextOwner == null)
                return null;

            ChangeReferenceOwner(currentOwner, nextOwner, reference);
            _topicsRepository.SaveChanges();
            return reference;
        }
        protected virtual void ChangeReferenceOwner(Topic currentOwner, Topic nextOwner, Reference reference)
        {
            currentOwner.References.Remove(reference);
            reference.Owner = nextOwner;
            nextOwner.References.Add(reference);
        }

        // TODO [FIX] This is a stub. Actually, this question should be answered by the repository which is who
        //  actually handles how to identify the Uniserve topic.
        //  Also, it remains untested for this very same reason.
        public virtual bool IsUniverseTopic(long id)
        {
            return id == 1;
        }

        // TODO [TEST] I forgot to test that the topic has an owner!!!
        public Topic AddTopic(long ownerId, Topic newTopic, IEnumerable<long> referencesId)
        {
            if (newTopic == null)
                throw new ArgumentException("New Topic argument cannot be null.");
            if (referencesId == null)
                throw new ArgumentException("References Id argument cannot be null.");

            var owner = _topicsRepository.GetById(ownerId);
            if (owner == null)
                return null;

            newTopic.Owner = owner;
            newTopic = _topicsRepository.Add(newTopic);
            if (newTopic == null)
                return null;

            foreach (var refId in referencesId)
            {
                var reference = owner.References.FirstOrDefault(r => r.Id == refId);
                if (reference != null)
                    ChangeReferenceOwner(owner, newTopic, reference);
            }

            _topicsRepository.SaveChanges();
            return newTopic;
        }

        // TODO [TEST] me
        public List<Reference> GetReferencesFrom(long topicId)
        {
            var result = (List<Reference>)null;

            var topic = _topicsRepository.GetById(topicId);
            if (topic != null)
                result = topic.References.OrderBy(r => r.Name).ThenBy(r => r.Id).ToList();

            return result;
        }
    }
}