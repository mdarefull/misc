using KnowledgeMap.Data.Models;
using System.Collections.Generic;

namespace KnowledgeMap.Business.Abstracts
{
    public interface IHomeServices
    {
        Topic GetTopic(long id);

        Reference RemoveReference(long id);

        Reference AddReference(long topicId, Reference newReference);

        Topic RemoveTopic(long id, bool keepSubtopics = false, bool keepReferences = false);

        Reference ChangeReferenceOwner(long currentOwnerId, long refId, long nextOwnerId);

        bool IsUniverseTopic(long id);

        Topic AddTopic(long ownerId, Topic newTopic, IEnumerable<long> referencesId);

        List<Reference> GetReferencesFrom(long topicId);
    }
}