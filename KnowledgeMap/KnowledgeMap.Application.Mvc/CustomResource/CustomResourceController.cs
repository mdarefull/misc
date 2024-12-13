using CommonStore.Application.Wrappers;
using KnowledgeMap.Application.Mvc.CustomResource.ViewModels;
using KnowledgeMap.Business.Abstracts;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Resource = KnowledgeMap.Data.Models.CustomResource;

namespace KnowledgeMap.Application.Mvc.CustomResource
{
    public class CustomResourceController : Controller
    {
        private readonly ICustomResourceServices _resourceServices;
        private readonly ModelMapperWrapper _mapper;
        public CustomResourceController(ICustomResourceServices resourceServices, ModelMapperWrapper mapper)
        {
            _resourceServices = resourceServices;
            _mapper = mapper;
        }

        public ActionResult List()
        {
            var resources = _resourceServices.GetAll();
            var vm = _mapper.Map<List<Resource>, List<CustomResourceViewModel>>(resources);

            // Diplays all resources.
            return View(vm);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View(new UploadCustomResourceViewModel());
        }
        [HttpPost]
        public ActionResult Upload(UploadCustomResourceViewModel newVm)
        {
            if (ModelState.IsValid)
            {
                var resource = _mapper.Map<UploadCustomResourceViewModel, Resource>(newVm);
                UploadFile(resource, newVm.File);

                _resourceServices.Add(resource);

                return RedirectToAction("List");
            }
            else
                return View();
        }
        // TODO [UNDERSTAND] At first, this may seem dangerous (and it is), 
        //  but the problem lies on the way we serve the file, not how we upload it.
        //  Because we don't streamlined when serving the file, it is purposeless to
        //  streamlined the uploading. After all, we'll load the file entirely when
        //  serving it.
        private void UploadFile(Resource resource, HttpPostedFileBase file)
        {
            resource.MimeType = file.ContentType;
            resource.File = new byte[file.ContentLength];
            file.InputStream.Read(resource.File, 0, resource.File.Length);
        }

        public ActionResult Get(long resourceId)
        {
            var resource = _resourceServices.Get(resourceId);
            if (resource == null)
                return null;
            else
                return File(resource.File, resource.MimeType);
        }
    }
}