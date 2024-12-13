using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.Home.ViewModels
{
    [DisplayName("SubTopic")]
    public class SubTopicViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Description { get; set; }
    }
}