using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.Home.ViewModels
{
    [DisplayName("New Topic")]
    public class AddTopicViewModel
    {
        public AddTopicViewModel()
        {
            References = new List<AddTopic_ReferenceViewModel>();
        }

        [Required]
        [Range(1, long.MaxValue)]
        [HiddenInput(DisplayValue = false)]
        public long OwnerId { get; set; }

        [Required]
        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Description:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [UIHint("Collection")]
        public List<AddTopic_ReferenceViewModel> References { get; set; }
    }

    public class AddTopic_ReferenceViewModel
    {
        [Required]
        [Range(1, long.MaxValue)]
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}