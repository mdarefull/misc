using CommonStore.EF.Repositories;
using CommonStore.Models.Pcl;
using KnowledgeMap.Data.Models;
using KnowledgeMap.Tests.Data.EF._TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace KnowledgeMap.Tests.Data.EF
{
    [TestClass]
    public class TopicsRepositoryTest : KnowledgeMapDbTestBase
    {
        public override void Coverage_TestedMethods_Matches()
        {
            // So far, no needed...
        }

        [TestMethod]
        public void TopicsRepository_AddReferenceToTopicsList_ChangesSaved()
        {
            // Arrange
            var newReference = new Reference { Name = "TestName", TargetUrl = "TestUrl" };
            var target = GetTopicsRepository();
            var topic = target.GetById(TestTopics[0].Id);
            var initialReferencesCount = topic.References.Count;

            // Act
            topic.References.Add(newReference);
            target.SaveChanges();

            // Assert
            target = GetTopicsRepository();
            topic = target.GetById(topic.Id);
            newReference = topic.References.FirstOrDefault(r => r.Id == newReference.Id);

            Assert.IsNotNull(newReference);
            Assert.AreNotEqual(newReference.Id, 0);
            Assert.AreSame(newReference.Owner, topic);
            Assert.AreEqual(initialReferencesCount + 1, topic.References.Count);
            CollectionAssert.Contains(topic.References, newReference);
        }

        [TestMethod]
        public void TopicsRepository_ChangeReferencesPropertyOwnerOnly_ChangesSaved()
        {
            // Arrange
            var target = GetTopicsRepository();
            var topic = target.GetById(TestTopics[0].SubTopics[0].Id);
            var initialOwnerReferencesCount = topic.Owner.References.Count;
            var references = topic.References.ToList();

            // Act
            topic.References.Clear();
            references.ForEach(r => r.Owner = topic.Owner);
            topic.Owner.References.AddRange(references);
            target.SaveChanges();

            // Assert
            target = GetTopicsRepository();
            topic = target.GetById(topic.Id);

            Assert.AreEqual(0, topic.References.Count);
            Assert.AreEqual(initialOwnerReferencesCount + references.Count, topic.Owner.References.Count);
            CollectionAssert.IsSubsetOf(references, topic.Owner.References);
            foreach (var reference in references)
                Assert.AreEqual(topic.Owner, reference.Owner);
        }

        [TestMethod]
        public void TopicsRepository_ChangeSubtopicsOwner_ChangesSaved()
        {
            // Arrange
            var target = GetTopicsRepository();
            var topic = target.GetById(TestTopics[0].SubTopics[0].Id);
            var initialOwnerSubtopicsCount = topic.Owner.SubTopics.Count;
            var subTopics = topic.SubTopics.ToList();

            // Act
            topic.SubTopics.Clear();
            subTopics.ForEach(s => s.Owner = topic.Owner);
            topic.Owner.SubTopics.AddRange(subTopics);
            target.SaveChanges();

            // Assert
            target = GetTopicsRepository();
            topic = target.GetById(topic.Id);

            Assert.AreEqual(0, topic.SubTopics.Count);
            Assert.AreEqual(initialOwnerSubtopicsCount + subTopics.Count, topic.Owner.SubTopics.Count);
            CollectionAssert.IsSubsetOf(subTopics, topic.Owner.SubTopics);
            foreach (var subtopic in subTopics)
                Assert.AreEqual(topic.Owner, subtopic.Owner);
        }
        [TestMethod]
        public void TopicRepository_PostOrderRemoveATopic_ChangesSaved()
        {
            // Arrange
            var context = GetDbContext();
            var topicRepo = GetTopicsRepository(context);
            var refRepo = GetReferencesRepository(context);
            var topic = topicRepo.GetById(TestTopics[0].Id);

            // Act
            PostOrderRemove(topicRepo, refRepo, topic);
            topicRepo.SaveChanges();

            // Assert
            topicRepo = GetTopicsRepository();
            topic = topicRepo.GetById(topic.Id);

            Assert.IsNull(topic);
        }
        private void PostOrderRemove(IRepository<Topic, long> topicRepo, IRepository<Reference, long> refRepo,
                                     Topic topic)
        {
            foreach (var reference in topic.References.ToList())
                refRepo.Remove(reference.Id);
            topic.References.Clear();

            foreach (var subtopic in topic.SubTopics.ToList())
                PostOrderRemove(topicRepo, refRepo, subtopic);

            topicRepo.Remove(topic.Id);
        }

        private IRepository<Topic, long> GetTopicsRepository(DbContext context = null)
        {
            if (context == null)
                context = GetDbContext();
            return new DbContextRepository<Topic, long>(context);
        }
        private IRepository<Reference, long> GetReferencesRepository(DbContext context = null)
        {
            if (context == null)
                context = GetDbContext();
            return new DbContextRepository<Reference, long>(context);
        }
    }
}