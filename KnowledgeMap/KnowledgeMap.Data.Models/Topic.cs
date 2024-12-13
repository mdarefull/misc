using CommonStore.Models.Pcl;
using System.Collections.Generic;

namespace KnowledgeMap.Data.Models
{
    public class Topic : ModelBase<long>
    {
        public Topic()
        {
            SubTopics = new List<Topic>();
            References = new List<Reference>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Topic Owner { get; set; }
        public virtual List<Topic> SubTopics { get; set; }
        public virtual List<Reference> References { get; set; }

        protected override bool AreEquals(ModelBase<long> other)
        {
            return other is Topic;
        }
    }
}