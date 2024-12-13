using KnowledgeMap.Data.Models;
using System.Collections.Generic;

namespace KnowledgeMap.Business.Abstracts
{
    public interface ICustomResourceServices
    {
        List<CustomResource> GetAll();

        CustomResource Add(CustomResource newResource);

        CustomResource Get(long resourceId);
    }
}