using CommonStore.Tests;
using Effort.Provider;
using KnowledgeMap.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace KnowledgeMap.Tests.Data.EF._TestData
{
    /// <summary>
    /// The goal of this test class, is to ensure the correct set up of the Db.
    /// We need to ensure the following behaviors: 
    ///     1: this.InstantiateDbcontext() instantiates a context with EffortConnection
    ///     2: this.TestInitialize() Initializes the Db with the declared sample data.
    ///     3: 2 DbContexts belongs to the same test => share the same data.
    ///     4: 2 DbContexts belongs to different tests => won't share the same data.
    /// </summary>
    [TestClass]
    public class KnowledgeMapTestDbConfigTest : KnowledgeMapDbTestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            // This needs to be done to force the loading of MySolutionTestDbConfig before explicitly loading the context.
            DbConfiguration.SetConfiguration(new KnowledgeMapTestDbConfig());
        }

        // 0
        [TestMethod]
        public sealed override void Coverage_TestedMethods_Matches()
        {
            // Arrange
            var testedMethodNames = new[] { "get_TestTopics", "get_TestReferences", "get_TestResources", "TestInitialize", "TestCleanup", "InstantiateDbContext", };
            var target = this.GetType().BaseType;

            // Act && Assert
            this.Coverage_TestedMethods_Matches(testedMethodNames, target, BindingFlags.NonPublic);
        }

        // 1
        [TestMethod]
        public void This_InstantiateDbContext_DbConnectionIsEffortConnection()
        {
            // Arrange
            var connection = (DbConnection)null;
            var expected = typeof(EffortConnection);

            // Act
            connection = InstantiateDbContext().Database.Connection;

            // Assert
            Assert.IsInstanceOfType(connection, expected);
        }

        // 2
        [TestMethod]
        public void This_TestInitialize_InitializesDbWithSampleData()
        {
            // Arrange
            var expected = TestTopics;
            var actual = (List<Topic>)null;

            // Act
            actual = GetDbContext().Topics.ToList();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        // 3
        [TestMethod]
        public void TestSession_TwoDbContexts_ShareSameData()
        {
            // Arrange
            var newProduct = new Topic { Name = "TestTopicA", Owner = TestTopics[0] };
            var addedProduct = (Topic)null;

            // Act
            using (var db = GetDbContext())
            {
                newProduct = db.Topics.Add(newProduct);
                db.SaveChanges();
            }
            using (var db = GetDbContext())
                addedProduct = db.Topics.Find(newProduct.Id);

            // Assert
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual(newProduct, addedProduct);
        }

        // 4
        [TestMethod]
        public void TestSession_AddDataA_CannotSeeDataB()
        {
            // Arrange
            var topicA = new Topic { Name = MethodBase.GetCurrentMethod().Name, Owner = TestTopics[0] };
            var topicB = (Topic)null;
            var methodBName = GetType().GetMethod("TestSession_AddDataB_CannotSeeDataA").Name;

            // Act
            using (var db = GetDbContext())
            {
                topicA = db.Topics.Add(topicA);
                db.SaveChanges();
            }
            using (var db = GetDbContext())
                topicB = db.Topics.FirstOrDefault(p => p.Name == methodBName);

            // Assert
            Assert.IsNull(topicB);
        }
        [TestMethod]
        public void TestSession_AddDataB_CannotSeeDataA()
        {
            // Arrange
            var topicB = new Topic { Name = MethodBase.GetCurrentMethod().Name, Owner = TestTopics[0] };
            var topicA = (Topic)null;
            var methodAName = GetType().GetMethod("TestSession_AddDataA_CannotSeeDataB").Name;

            // Act
            using (var db = GetDbContext())
            {
                topicB = db.Topics.Add(topicB);
                db.SaveChanges();
            }
            using (var db = GetDbContext())
                topicA = db.Topics.FirstOrDefault(p => p.Name == methodAName);

            // Assert
            Assert.IsNull(topicA);
        }
    }
}