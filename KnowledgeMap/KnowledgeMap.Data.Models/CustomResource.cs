using CommonStore.Models.Pcl;

namespace KnowledgeMap.Data.Models
{
    public class CustomResource : ModelBase<long>
    {
        public string Name { get; set; }

        public byte[] File { get; set; }
        public string MimeType { get; set; }

        protected override bool AreEquals(ModelBase<long> other)
        {
            return other is CustomResource;
        }
    }
}