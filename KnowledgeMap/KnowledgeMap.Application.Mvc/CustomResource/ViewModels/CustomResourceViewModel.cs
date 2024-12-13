using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeMap.Application.Mvc.CustomResource.ViewModels
{
    [DisplayName("Custom Resource")]
    public class CustomResourceViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}