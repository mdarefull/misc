using CommonStore.Application.Wrappers;
using CommonStore.Application.Wrappers.Fakes;
using CommonStore.Tests;
using KnowledgeMap.Application.Mvc.Home;
using KnowledgeMap.Application.Mvc.Home.ViewModels;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Business.Abstracts.Fakes;
using KnowledgeMap.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace KnowledgeMap.Tests.Application.Mvc.Home
{
    [TestClass]
    public class HomeControllerTest : IMyTest
    {
        [TestMethod]
        public void Coverage_TestedMethods_Matches()
        {
            // Arrange
            var testedMethodNames = new[] { "Index", "Topic", "RemoveTopic", 
                                            "AddReference", "RemoveReference", 
                                            "IsUniverseTopic", "AddTopic", "AddTopic" };
            var target = typeof(HomeController);

            // Act & Assert
            this.Coverage_TestedMethods_Matches(testedMethodNames, target);
        }

        #region Index()
        // 1
        [TestMethod]
        public void Index_Invoke_PermanentRedirectionToUniverse()
        {
            // Arrange
            var target = GetHomeController();

            // Act
            var actual = target.Index();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsTrue(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
                {
                    action = "Topic",
                    topicName = "Universe",
                    topicId = 1,
                }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        #endregion

        #region Topic()
        // 2
        [TestMethod]
        public void Topic_AnyInput_PassesSameIdToService()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIHomeServices
            {
                GetTopicInt64 = id =>
                {
                    actual = id;
                    return null;
                }
            };
            var target = GetHomeController(stub);

            // Act
            target.Topic(null, expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // 3
        [TestMethod]
        public void Topic_UnexistentTopic_NotFound()
        {
            // Arrange
            var stub = new StubIHomeServices { GetTopicInt64 = id => null };
            var target = GetHomeController(stub);

            // Act
            var actual = target.Topic(null);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(HttpNotFoundResult));

            var actualType = (HttpNotFoundResult)actual;
            Assert.AreEqual(404, actualType.StatusCode);
            StringAssert.Contains(actualType.StatusDescription, "The requested topic doesn't exist");
        }

        // 4
        [TestMethod]
        public void Topic_BadTittle_PermanentRedirectionToCorrect()
        {
            // Arrange
            var expectedTopic = new Topic { Name = "TopicName", Id = 10, };
            var stub = new StubIHomeServices { GetTopicInt64 = id => expectedTopic, };
            var target = GetHomeController(stub);

            // Act
            var actual = target.Topic(expectedTopic.Name.ToLower());

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsTrue(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicName = expectedTopic.Name,
                topicId = expectedTopic.Id,
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }

        // 5
        [TestMethod]
        public void Topic_CorrectArgs_PassesTopicToMapper()
        {
            // Arrange
            var expected = new Topic();
            var stubService = new StubIHomeServices { GetTopicInt64 = id => expected, };

            var actual = (Topic)null;
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<Topic, TopicViewModel>(t =>
            {
                actual = (Topic)t;
                return null;
            });

            var target = GetHomeController(stubService, stubMapper);

            // Act
            target.Topic(null);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        // 6
        [TestMethod]
        public void Topic_CorrectArgs_TopicView()
        {
            // Arrange
            var stubService = new StubIHomeServices { GetTopicInt64 = id => new Topic(), };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<Topic, TopicViewModel>(t => null);
            var target = GetHomeController(stubService, stubMapper);

            // Act
            var actual = target.Topic(null);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            var actualType = (ViewResult)actual;
            Assert.IsTrue(string.IsNullOrEmpty(actualType.ViewName));
        }

        // 7
        [TestMethod]
        public void Topic_CorrectArgs_ViewWithCorrectViewModel()
        {
            // Arrange
            var stubService = new StubIHomeServices { GetTopicInt64 = id => new Topic(), };

            var expected = new TopicViewModel();
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<Topic, TopicViewModel>(t => expected);

            var target = GetHomeController(stubService, stubMapper);

            // Act
            var actual = (target.Topic(null) as ViewResult).Model;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(TopicViewModel));
            Assert.AreSame(expected, actual);
        }
        #endregion

        #region Remove (Reference)
        // 8
        [TestMethod]
        public void Remove_AnyArgs_InvokeServiceRemoveWithSameArgs()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIHomeServices
            {
                RemoveReferenceInt64 = rId =>
                    {
                        actual = rId;
                        return null;
                    },
            };
            var target = GetHomeController(stub);

            // Act
            target.RemoveReference(expected, null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // 9
        [TestMethod]
        public void Remove_NullReturnUrl_TemporaryRedirectToUniverse()
        {
            // Arrange
            var stub = new StubIHomeServices { RemoveReferenceInt64 = rId => null };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveReference(-1, null);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
                {
                    action = "Topic",
                    topicName = "Universe",
                    topicId = 1,
                }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        [TestMethod]
        public void Remove_EmptyReturnUrl_TemporaryRedirectsToUniverse()
        {
            // Arrange
            var stub = new StubIHomeServices { RemoveReferenceInt64 = rId => null };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveReference(-1, string.Empty);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
                {
                    action = "Topic",
                    topicName = "Universe",
                    topicId = 1,
                }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }

        // 10
        [TestMethod]
        public void Remove_ReturnUrl_TemporaryRedirectsToUrl()
        {
            // Arrange
            var expectedUrl = "~/HelloWorld";
            var stub = new StubIHomeServices { RemoveReferenceInt64 = rId => null };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveReference(-1, expectedUrl);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectResult));

            var actualType = (RedirectResult)actual;
            Assert.IsFalse(actualType.Permanent);
            Assert.AreEqual(expectedUrl, actualType.Url);
        }
        #endregion

        #region Add (Reference)
        // 11
        [TestMethod]
        public void Add_InvalidModel_DoNotInvokeMapperNorService()
        {
            // Arrange
            var serviceInvoked = false;
            var stubService = new StubIHomeServices
            {
                AddReferenceInt64Reference = (tId, newR) =>
                    {
                        serviceInvoked = true;
                        return null;
                    }
            };

            var mapperInvoked = false;
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<TopicReferenceViewModel, Reference>(vm =>
                {
                    mapperInvoked = true;
                    return null;
                });

            var target = GetHomeController(stubService, stubMapper);
            target.ModelState.AddModelError("testErrorKey", "testErrorMessage");

            // Act
            target.AddReference(-1, new TopicReferenceViewModel());

            // Assert
            Assert.IsFalse(mapperInvoked);
            Assert.IsFalse(serviceInvoked);
        }

        // 12
        [TestMethod]
        public void Add_ValidArgs_PassVmToMapper()
        {
            // Arrange
            var expected = new TopicReferenceViewModel();
            var actual = (TopicReferenceViewModel)null;

            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<TopicReferenceViewModel, Reference>(vm =>
            {
                actual = (TopicReferenceViewModel)vm;
                return null;
            });

            var target = GetHomeController(mapper: stubMapper);

            try
            {
                // Act
                target.AddReference(-1, expected);
            }
            catch { }

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }

        // 13
        [TestMethod]
        public void Add_ValidArgs_PassIdAndModelToServiceAddReference()
        {
            // Arrange
            var expected = new { tId = 10L, Reference = new Reference() };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<TopicReferenceViewModel, Reference>(vm => expected.Reference);

            var actual = new { tId = expected.tId - 1, Reference = (Reference)null };
            var stubServices = new StubIHomeServices
            {
                AddReferenceInt64Reference = (tId, newR) =>
                    {
                        actual = new { tId, Reference = newR };
                        return null;
                    }
            };
            var target = GetHomeController(stubServices, stubMapper);

            // Act
            target.AddReference(expected.tId, new TopicReferenceViewModel());

            // Assert
            Assert.AreEqual(expected.tId, actual.tId);
            Assert.AreSame(expected.Reference, actual.Reference);
        }

        // 14
        [TestMethod]
        public void Add_AnyArgs_RedirectToTopicId()
        {
            // Arrange
            var stubService = new StubIHomeServices { AddReferenceInt64Reference = (tId, r) => new Reference(), };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<TopicReferenceViewModel, Reference>(vm => new Reference());
            var target = GetHomeController(stubService, stubMapper);
            var expectedId = 10L;

            // Act
            var actual = target.AddReference(expectedId, new TopicReferenceViewModel());

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
                {
                    action = "Topic",
                    topicId = expectedId,
                }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        #endregion

        #region Remove (Topic)
        [TestMethod]
        public void Remove_AnyArgs_PassesIdToServiceIsUniverse()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIHomeServices
            {
                IsUniverseTopicInt64 = id =>
                    {
                        actual = id;
                        return false;
                    }
            };
            var target = GetHomeController(stub);

            // Act
            target.RemoveTopic(expected, false, false);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Remove_UniverseTopic_Error()
        {
            // Arrange
            var stub = new StubIHomeServices { IsUniverseTopicInt64 = id => true };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveTopic(-1, false, false);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(HttpStatusCodeResult));

            var actualType = (HttpStatusCodeResult)actual;
            Assert.AreEqual(actualType.StatusCode, (int)HttpStatusCode.Forbidden);
            StringAssert.Contains(actualType.StatusDescription, "The Universe Topic cannot be removed");
        }

        [TestMethod]
        public void Remove_AnyArgs_PassesArgsToServiceRemove()
        {
            // Arrange
            var expected = new { tId = 10L, ks = true, kr = false };
            var actual = new { tId = expected.tId - 1, ks = !expected.ks, kr = !expected.kr };
            var stub = new StubIHomeServices
            {
                RemoveTopicInt64BooleanBoolean = (tId, ks, kr) =>
                    {
                        actual = new { tId, ks, kr };
                        return null;
                    },
            };
            var target = GetHomeController(stub);

            // Act
            target.RemoveTopic(expected.tId, expected.ks, expected.kr);

            // Assert
            Assert.AreEqual(expected.tId, actual.tId);
            Assert.AreEqual(expected.ks, actual.ks);
            Assert.AreEqual(expected.kr, actual.kr);
        }

        [TestMethod]
        public void Remove_ServiceReturnsNull_TemporaryRedirectToTopicId()
        {
            // Arrange
            var expectedTopicId = 10L;
            var stub = new StubIHomeServices { RemoveTopicInt64BooleanBoolean = (tId, ks, kr) => null };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveTopic(expectedTopicId, false, false);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicId = expectedTopicId,
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }

        [TestMethod]
        public void Remove_ServiceReturnsTopic_TemporaryRedirectToTopicOwner()
        {
            // Arrange
            var topicOwner = new Topic { Id = 10, Name = "TestName" };
            var stub = new StubIHomeServices
            {
                RemoveTopicInt64BooleanBoolean = (tId, ks, kr) => topicOwner,
            };
            var target = GetHomeController(stub);

            // Act
            var actual = target.RemoveTopic(-1, false, false);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicId = topicOwner.Id,
                topicName = topicOwner.Name,
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        #endregion

        #region IsUniverseTopic
        [TestMethod]
        public void IsUniverseTopic_AnyArg_PassesSameArgToService()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIHomeServices
            {
                IsUniverseTopicInt64 = id =>
                {
                    actual = id;
                    return false;
                }
            };
            var target = GetHomeController(stub);

            // Act
            target.IsUniverseTopic(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsUniverseTopic_AnyArg_ReturnSameThanService()
        {
            // Arrange
            var expected = true;
            var stub = new StubIHomeServices { IsUniverseTopicInt64 = id => expected };
            var target = GetHomeController(stub);

            // Act
            var actual = target.IsUniverseTopic(-1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddTopic
        [TestMethod]
        public void AddTopic_AnyArgs_PassArgsToMapper()
        {
            // Arrange
            var expected = new AddTopicViewModel();
            var actual = (AddTopicViewModel)null;

            var stub = new StubModelMapperWrapper();
            stub.MapOf2M0<AddTopicViewModel, Topic>(vm =>
            {
                actual = vm;
                return null;
            });
            var target = GetHomeController(mapper: stub);

            // Act
            target.AddTopic(expected);

            // Assert
            Assert.AreSame(expected, actual);
        }
        [TestMethod]
        public void AddTopic_NullTopic_TemporaryRedirectToOwnerId()
        {
            // Arrange
            var ownerId = 10L;
            var stub = new StubModelMapperWrapper();
            stub.MapOf2M0<AddTopicViewModel, Topic>(vm => null);
            var target = GetHomeController(mapper: stub);

            // Act
            var actual = target.AddTopic(new AddTopicViewModel { OwnerId = ownerId });

            // Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicId = ownerId,
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        [TestMethod]
        public void AddTopic_CorrectTopic_PassArgumentsToService()
        {
            // Arrange
            var expected = new
            {
                ViewModel = new AddTopicViewModel { OwnerId = 10L, References = new List<AddTopic_ReferenceViewModel>() },
                Topic = new Topic(),
            };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<AddTopicViewModel, Topic>(vm => expected.Topic);

            var actual = new
            {
                OwnerId = expected.ViewModel.OwnerId - 1,
                Topic = (Topic)null,
                ReferencesId = (IEnumerable<long>)null,
            };
            var stubService = new StubIHomeServices
            {
                AddTopicInt64TopicIEnumerableOfInt64 = (oId, nT, refs) =>
                    {
                        actual = new
                        {
                            OwnerId = oId,
                            Topic = nT,
                            ReferencesId = refs,
                        };
                        return new Topic();
                    },
            };
            var target = GetHomeController(stubService, stubMapper);

            // Act
            target.AddTopic(expected.ViewModel);

            // Assert
            Assert.AreEqual(expected.ViewModel.OwnerId, actual.OwnerId);
            Assert.AreSame(expected.Topic, actual.Topic);
            Assert.AreSame(expected.ViewModel.References, actual.ReferencesId);
        }
        [TestMethod]
        public void AddTopic_NullAdd_TemporaryRedirectToOwnerId()
        {
            // Arrange
            var ownerId = 10L;
            var stubService = new StubIHomeServices
            {
                AddTopicInt64TopicIEnumerableOfInt64 = (id, t, refs) => null
            };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<AddTopicViewModel, Topic>(vm => new Topic());
            var target = GetHomeController(stubService, stubMapper);

            // Act
            var actual = target.AddTopic(new AddTopicViewModel { OwnerId = ownerId });

            // Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicId = ownerId,
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        [TestMethod]
        public void AddTopic_CorrectAdd_TemporaryRedirectToTopicId()
        {
            // Arrange
            var topicId = 10L;
            var topicName = "SomeTopi";
            var stubService = new StubIHomeServices
            {
                AddTopicInt64TopicIEnumerableOfInt64 = (id, t, refs) => new Topic { Id = topicId, Name = topicName },
            };
            var stubMapper = new StubModelMapperWrapper();
            stubMapper.MapOf2M0<AddTopicViewModel, Topic>(vm => new Topic());
            var target = GetHomeController(stubService, stubMapper);

            // Act
            var actual = target.AddTopic(new AddTopicViewModel());

            // Assert
            Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));

            var actualType = (RedirectToRouteResult)actual;
            Assert.IsFalse(actualType.Permanent);

            var expectedValues = new RouteValueDictionary(new
            {
                action = "Topic",
                topicName,
                topicId
            }).ToList();
            var actualValues = actualType.RouteValues.ToList();
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
        #endregion

        private HomeController GetHomeController(IHomeServices service = null, ModelMapperWrapper mapper = null)
        {
            return new HomeController(service, mapper);
        }
    }
}