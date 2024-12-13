using CommonStore.Application.Abstracts;
using ExpressMapper;
using KnowledgeMap.Application.Mvc.Home.ViewModels;
using KnowledgeMap.Data.Models;

namespace KnowledgeMap.Application.Mvc.Home.Infrastructure
{
    public class ModelMappingRegistrar : IModelMappingRegistrar
    {
        public void RegisterMappings()
        {
            // Register your Home use-case level models-vm mappings here.

            Mapper.Register<AddTopicViewModel, Topic>()
                  .Ignore(dest => dest.References);
        }
    }
}