using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.Home.ViewModels
{
    [DisplayName("Topic")]
    public class TopicViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Description:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [UIHint("Collection")]
        public List<SubTopicViewModel> SubTopics { get; set; }

        [UIHint("Collection")]
        public List<TopicReferenceViewModel> References { get; set; }
    }
}