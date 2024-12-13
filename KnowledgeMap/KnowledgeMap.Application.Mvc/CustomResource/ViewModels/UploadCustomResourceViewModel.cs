using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace KnowledgeMap.Application.Mvc.CustomResource.ViewModels
{
    [DisplayName("New Custom Resource")]
    public class UploadCustomResourceViewModel
    {
        [Required]
        [DisplayName("Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DisplayName("File:")]
        public HttpPostedFileBase File { get; set; }
    }
}