using CommonStore.Models.Pcl;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeMap.Business.Services
{
    public class CustomResourceServices : ICustomResourceServices
    {
        private readonly IRepository<CustomResource, long> _resourcesRepository;
        public CustomResourceServices(IRepository<CustomResource, long> resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public List<CustomResource> GetAll()
        {
            var resources = _resourcesRepository.GetAll()
                                                .Select(r => new { r.Id, r.Name })
                                                .OrderBy(r => r.Name)
                                                .ThenBy(r => r.Id)
                                                .ToList()
                                                .Select(r => new CustomResource { Id = r.Id, Name = r.Name })
                                                .ToList();
            return resources;
        }

        public CustomResource Add(CustomResource newResource)
        {
            if (newResource == null)
                throw new ArgumentException("Argument cannot be null.");
            return _resourcesRepository.AddAtomic(newResource);
        }

        public CustomResource Get(long resourceId)
        {
            return _resourcesRepository.GetById(resourceId);
        }
    }
}