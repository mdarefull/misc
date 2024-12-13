using CommonStore.EF.Repositories;
using CommonStore.Models.Pcl;
using KnowledgeMap.Data.Models;
using KnowledgeMap.Tests.Data.EF._TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KnowledgeMap.Tests.Data.EF
{
    [TestClass]
    public class CustomResourcesRepositoryTest : KnowledgeMapDbTestBase
    {
        public override void Coverage_TestedMethods_Matches()
        {
            // So far, no needed...
        }

        [TestMethod]
        public void GetAll_Invoked_AllResourcesReturned()
        {
            // Arrange
            var expected = this.TestResources.ToList();
            var target = GetRepository();

            // Act
            var actual = target.GetAll()
                               .Select(r => new { r.Id, r.Name })
                               .OrderBy(r => r.Name)
                               .ThenBy(r => r.Id)
                               .ToList()
                               .Select(r => new CustomResource { Id = r.Id, Name = r.Name })
                               .ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        private IRepository<CustomResource, long> GetRepository()
        {
            return new DbContextRepository<CustomResource, long>(GetDbContext());
        }
    }
}