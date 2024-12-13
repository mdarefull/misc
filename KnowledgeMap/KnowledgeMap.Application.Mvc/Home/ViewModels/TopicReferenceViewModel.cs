using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.Home.ViewModels
{
    [DisplayName("Reference")]
    public class TopicReferenceViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Url:")]
        [DataType(DataType.Url)]
        [Required]
        public string TargetUrl { get; set; }
    }
}