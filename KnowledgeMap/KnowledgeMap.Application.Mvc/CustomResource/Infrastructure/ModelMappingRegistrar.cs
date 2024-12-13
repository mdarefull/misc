using CommonStore.Application.Abstracts;
using ExpressMapper;
using KnowledgeMap.Application.Mvc.CustomResource.ViewModels;

namespace KnowledgeMap.Application.Mvc.CustomResource.Infrastructure
{
    public class ModelMappingRegistrar : IModelMappingRegistrar
    {
        public void RegisterMappings()
        {
            // Register your Resource use-case level models-vm mappings here.

            Mapper.Register<UploadCustomResourceViewModel, KnowledgeMap.Data.Models.CustomResource>()
                  .Ignore(dest => dest.File);
        }
    }
}