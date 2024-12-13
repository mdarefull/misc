using CommonStore.Models.Pcl;
using System;

namespace KnowledgeMap.Data.Models
{
    public class Reference : ModelBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetUrl { get; set; }
        public virtual Topic Owner { get; set; }

        protected override bool AreEquals(ModelBase<long> other)
        {
            return other is Reference;
        }
    }
}