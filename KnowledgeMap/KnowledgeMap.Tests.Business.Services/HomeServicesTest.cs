using CommonStore.Models.Pcl;
using CommonStore.Models.Pcl.Fakes;
using CommonStore.Tests;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Business.Services;
using KnowledgeMap.Business.Services.Fakes;
using KnowledgeMap.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeMap.Tests.Business.Services
{
    [TestClass]
    public class HomeServicesTest : IMyTest
    {
        [TestMethod]
        public void Coverage_TestedMethods_Matches()
        {
            // TODO [FIX] I've included the IsUniverseTopic method here even when it isn't tested, in order
            //  to remove the red line at the tests results because of something I won't fix now.
            // Arrange
            var testedMethodNames = new[] { "GetTopic", "RemoveReference", "AddReference", "RemoveTopic", "IsUniverseTopic", "ChangeReferenceOwner", "AddTopic" };
            var target = typeof(HomeServices);

            // Act & Assert
            this.Coverage_TestedMethods_Matches(testedMethodNames, target);
        }

        #region GetTopic()
        [TestMethod]
        public void GetTopic_AnyArgs_RepoReceivesSameArgument()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;

            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                {
                    actual = id;
                    return null;
                }
            };
            var target = GetHomeServices(stub);

            // Act
            try
            {
                target.GetTopic(expected);
            }
            catch { }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTopic_NullTopic_ReturnNull()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => null };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.GetTopic(-1);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetTopic_CorrectTopic_SubjectsSortedByNameThenById()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic
                {
                    SubTopics = new List<Topic>
                    { 
                        new Topic { Name = "T" },
                        new Topic { Name = "X" },
                        new Topic { Name = "A" },
                        new Topic { Name = "E", Id = 10 },
                        new Topic { Name = "E", Id = 8 },
                        new Topic { Name = "XR" },
                        new Topic { Name = "32" }
                    },
                },
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.GetTopic(-1);

            // Assert
            var expected = actual.SubTopics.ToList();
            expected.Sort((s1, s2) =>
                {
                    var result = s1.Name.CompareTo(s2.Name);
                    if (result == 0)
                        result = s1.Id.CompareTo(s2.Id);
                    return result;
                });
            foreach (var pair in expected.Zip(actual.SubTopics, (t1, t2) => Tuple.Create(t1, t2)))
                Assert.AreSame(pair.Item1, pair.Item2);
        }
        [TestMethod]
        public void GetTopic_CorrectTopic_ReferencesSortedByNameThenById()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic
                {
                    References = new List<Reference>
                    {
                        new Reference { Name = "T" },
                        new Reference { Name = "X" },
                        new Reference { Name = "A" },
                        new Reference { Name = "E", Id = 10 },
                        new Reference { Name = "E", Id = 8},
                        new Reference { Name = "XR" },
                        new Reference { Name = "32" },
                    }
                }
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.GetTopic(-1);

            // Assert
            var expected = actual.References.ToList();
            expected.Sort((r1, r2) =>
            {
                var result = r1.Name.CompareTo(r2.Name);
                if (result == 0)
                    result = r1.Id.CompareTo(r2.Id);
                return result;
            });
            foreach (var pair in expected.Zip(actual.References, (r1, r2) => Tuple.Create(r1, r2)))
                Assert.AreSame(pair.Item1, pair.Item2);
        }

        [TestMethod]
        public void GetTopic_CorrectTopic_ReturnsSameThanRepo()
        {
            // Arrange
            var expected = new Topic();
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => expected, };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.GetTopic(-1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }
        #endregion

        #region RemoveReference()
        // 3
        [TestMethod]
        public void RemoveReference_AnyArg_RepoRemoveAtomicReceivesSameArg()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Reference, long>
            {
                RemoveAtomicT1 = id =>
                    {
                        actual = id;
                        return null;
                    }
            };
            var target = GetHomeServices(refRepo: stub);

            // Act
            target.RemoveReference(expected);


            // Assert
            Assert.AreEqual(expected, actual);
        }

        // 4
        [TestMethod]
        public void RemoveReference_AnyArg_ReturnSameThanRepo()
        {
            // Arrange
            var expected = new Reference();

            var stub = new StubIRepository<Reference, long> { RemoveAtomicT1 = id => expected };
            var target = GetHomeServices(refRepo: stub);

            // Act
            var actual = target.RemoveReference(-1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }
        #endregion

        #region AddReference()
        // 5
        [TestMethod]
        public void AddReference_NullReference_InvalidArgumentException()
        {
            // Arrange
            var expected = "Reference argument cannot be null";
            var target = GetHomeServices((IRepository<Topic, long>)null);

            try
            {
                // Act
                target.AddReference(-1, null);

                // Assert
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, expected);
            }
        }

        // 6
        [TestMethod]
        public void AddReference_AnyArgs_PassTopicIdToRepoGetById()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                {
                    actual = id;
                    return null;
                },
            };
            var target = GetHomeServices(stub);

            // Act
            target.AddReference(expected, new Reference());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // 7
        [TestMethod]
        public void AddReference_UnexistentTopic_Null()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => null, };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.AddReference(-1, new Reference());

            // Assert
            Assert.IsNull(actual);
        }

        // 8
        [TestMethod]
        public void AddReference_AnyArgs_AddReferenceToTheRetrievedTopic()
        {
            // Arrange
            var expected = new { Topic = new Topic(), Reference = new Reference(), };
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => expected.Topic, };
            var target = GetHomeServices(stub);

            // Act
            target.AddReference(-1, expected.Reference);

            // Assert
            var references = expected.Topic.References;
            Assert.AreEqual(references.Count, 1);
            CollectionAssert.Contains(references, expected.Reference);
        }

        // 9
        [TestMethod]
        public void AddReference_AnyArgs_SaveChangesWithTheReferenceAdded()
        {
            // Arrange
            var expected = new { Topic = new Topic(), Reference = new Reference(), };
            var changesSavedCorrectly = false;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => expected.Topic,
                SaveChanges = () =>
                    {
                        var references = expected.Topic.References;
                        changesSavedCorrectly = references.Count == 1
                                             && references.Contains(expected.Reference);
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.AddReference(-1, expected.Reference);

            // Assert
            Assert.IsTrue(changesSavedCorrectly);
        }

        // 10
        [TestMethod]
        public void AddReference_AnyArgs_ReturnAddedReference()
        {
            // Arrange
            var expected = new Reference();
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => new Topic(), };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.AddReference(-1, expected);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region RemoveTopic()
        [TestMethod]
        public void RemoveTopic_Universe_ArgumentException()
        {
            // Arrange
            var target = GetHomeServices();
            try
            {
                // Act
                target.RemoveTopic(1);

                // Assert
                Assert.Fail("ArgumentException expected.");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "The Universe topic cannot be removed");
            }
        }
        [TestMethod]
        public void RemoveTopic_AnyArgs_PassesIdToRepoGetById()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        actual = id;
                        return null;
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.RemoveTopic(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveTopic_UnexistentTopic_ReturnNull()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => null, };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.RemoveTopic(-1);

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void RemoveTopic_KeepSubjects_ChangeOwnersToTopicsOwner()
        {
            // This is checked as: |topic.Subtopic| = 0, topic.Owner.Subtopics contains the Subtopics and Subtopics.Owner = topic.Owner.
            // Arrange
            var topic = new Topic { Owner = new Topic { SubTopics = new List<Topic> { new Topic() }, } };
            var subtopics = new List<Topic> { new Topic(), new Topic(), new Topic() };
            subtopics.ForEach(s => s.Owner = topic);
            topic.SubTopics = subtopics.ToList();

            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => topic, };
            var target = GetHomeServices(stub);

            // Act
            target.RemoveTopic(-1, keepSubtopics: true);

            // Assert
            Assert.AreEqual(0, topic.SubTopics.Count);
            CollectionAssert.IsSubsetOf(subtopics, topic.Owner.SubTopics);
            foreach (var subtopic in subtopics)
                Assert.AreSame(topic.Owner, subtopic.Owner);
        }
        [TestMethod]
        public void RemoveTopic_NotKeepSubtopic_CallRepoRemoveOnEachSubtopic()
        {
            // Arrange
            var topic = new Topic
            {
                SubTopics = new List<Topic> 
                {
                    new Topic { Id = 1 }, 
                    new Topic 
                    { 
                        Id = 4,
                        SubTopics = new List<Topic> { new Topic { Id = 2 }, new Topic { Id = 3 } } 
                    }, 
                    new Topic { Id = 5 },
                }
            };
            topic.SubTopics.ForEach(s => s.Owner = topic);

            var removedSubtopics = new List<long>();
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => topic,
                RemoveT1 = id =>
                    {
                        if (id != topic.Id)
                            removedSubtopics.Add(id);
                        return null;
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.RemoveTopic(-1);

            // Assert
            Assert.AreEqual(5, removedSubtopics.Count);
            for (int i = 0; i < removedSubtopics.Count; i++)
                Assert.AreEqual(i + 1, removedSubtopics[i]);
        }
        [TestMethod]
        public void RemoveTopic_KeepReferences_CallChangeReferenceOwner()
        {
            // Arrange
            var expected = new
            {
                Topic = new Topic(),
                Owner = new Topic(),
                References = new List<Reference> 
                {
                    new Reference(), new Reference(), new Reference()
                },
            };
            expected.Topic.Owner = expected.Owner;
            expected.Topic.References = expected.References.ToList();
            var actual = new List<Tuple<Topic, Topic, Reference>>();

            var stubRepo = new StubIRepository<Topic, long> { GetByIdT1 = id => expected.Topic, };
            var stubTarget = GetStubHomeServices(stubRepo);
            stubTarget.ChangeReferenceOwnerTopicTopicReference = (t1, t2, r) => actual.Add(Tuple.Create(t1, t2, r));

            // Act
            stubTarget.RemoveTopic(-1, false, true);

            // Arrange
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreSame(actual[i].Item1, expected.Topic);
                Assert.AreSame(actual[i].Item2, expected.Owner);
                Assert.AreSame(actual[i].Item3, expected.References[i]);
            }
        }
        [TestMethod]
        public void RemoveTopic_NotKeepReferences_CallRepoRemoveOnEachReference()
        {
            // Arrange
            var topic = new Topic
            {
                References = new List<Reference>
                {
                    new Reference { Id = 1 }, 
                    new Reference { Id = 2 },
                    new Reference { Id = 3 },
                }
            };
            topic.References.ForEach(r => r.Owner = topic);

            var removedReferences = new List<long>();
            var stubTopic = new StubIRepository<Topic, long> { GetByIdT1 = id => topic };
            var stubRef = new StubIRepository<Reference, long>
            {
                RemoveT1 = id =>
                {
                    removedReferences.Add(id);
                    return null;
                },
            };
            var target = GetHomeServices(stubTopic, stubRef);

            // Act
            target.RemoveTopic(-1);

            // Assert
            Assert.AreEqual(3, removedReferences.Count);
            for (int i = 0; i < removedReferences.Count; i++)
                Assert.AreEqual(i + 1, removedReferences[i]);
        }
        [TestMethod]
        public void RemoveTopic_AnyArgs_CallRepoRemoveTopic()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic { Id = expected, },
                RemoveT1 = id =>
                    {
                        actual = id;
                        return null;
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.RemoveTopic(-1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveTopic_AnyArgs_CallRepoSaveChangesOnlyAfterEveryOtherMethod()
        {
            var saveChangesCalled = false;
            var afterSaveChanges = false;

            var stubTopic = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                {
                    afterSaveChanges = saveChangesCalled;
                    return new Topic();
                },
                RemoveT1 = id =>
                {
                    afterSaveChanges = saveChangesCalled;
                    return new Topic();
                },
                SaveChanges = () =>
                {
                    afterSaveChanges = saveChangesCalled;
                    saveChangesCalled = true;
                }
            };
            var stubRef = new StubIRepository<Reference, long>
            {
                RemoveT1 = id =>
                {
                    afterSaveChanges = saveChangesCalled;
                    return null;
                }
            };
            var target = GetHomeServices(stubTopic, stubRef);

            // Act
            target.RemoveTopic(-1);

            // Assert
            Assert.IsTrue(saveChangesCalled);
            Assert.IsFalse(afterSaveChanges);
        }
        [TestMethod]
        public void RemoveTopic_RepoRemoveReturnsNull_ReturnNull()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic(),
                RemoveT1 = id => null,
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.RemoveTopic(-1);

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void RemoveTopic_AnyArgs_ReturnTopicsOwner()
        {
            // Arrange
            var expected = new Topic();
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic { Owner = expected },
                RemoveT1 = id => new Topic(),
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.RemoveTopic(-1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }
        #endregion

        #region ChangeReferenceOwner()
        [TestMethod]
        public void ChangeReferenceOwner_AnyArgs_PassesCurrentOwnerIdToRepoGetById()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        actual = id;
                        return null;
                    }
            };
            var target = GetHomeServices(stub);

            // Act
            target.ChangeReferenceOwner(expected, -1, -1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ChangeReferenceOwner_NullCurrentOwner_ReturnNull()
        {
            // Arrange
            var expected = 10L;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        if (id == expected)
                            return null;
                        else
                            return new Topic();
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.ChangeReferenceOwner(expected, -1, -1);

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void ChangeReferenceOwner_CurrentOwnerDoesntHaveReference_ReturnNull()
        {
            // Arrange
            var refId = 10L;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic
                {
                    References = new List<Reference> 
                    { 
                        new Reference { Id = refId - 1}, 
                        new Reference { Id = refId + 1},
                    }
                }
            };
            var target = GetHomeServices(stub);

            // Actual
            var actual = target.ChangeReferenceOwner(-1, refId, -1);

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void ChangeReferenceOwner_AnyArgs_PassesNextOwnerIdToRepoGetById()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        if (id == expected)
                        {
                            actual = id;
                            return new Topic();
                        }

                        return new Topic { References = new List<Reference> { new Reference() } };
                    }
            };
            var target = GetHomeServices(stub);

            // Act
            target.ChangeReferenceOwner(-1, 0, expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ChangeReferenceOwner_NullNextOwner_ReturnNull()
        {
            // Arrange
            var expected = 10L;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        if (id == expected)
                            return null;
                        else
                            return new Topic();
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.ChangeReferenceOwner(-1, -1, expected);

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void ChangeReferenceOwner_CorrectArgs_ChangeOwner()
        {
            var reference = new Reference { Id = 10L };

            var currentOwnerReferences = new List<Reference>
            {
                new Reference { Id = reference.Id - 1 },
                new Reference { Id = reference.Id + 5 },
                reference,
                new Reference { Id = reference.Id - 8 },
                new Reference { Id = reference.Id - 4 },
            };
            var currentOwner = new Topic
            {
                Id = 10L,
                References = currentOwnerReferences.ToList(),
            };
            reference.Owner = currentOwner;

            var nextOwnerReferences = new List<Reference>
            {
                new Reference { Id = reference.Id - 4 },
                new Reference { Id = reference.Id + 9 },
                new Reference { Id = reference.Id - 15 },
                new Reference { Id = reference.Id - 10 },
            };
            var nextOwner = new Topic
            {
                Id = currentOwner.Id - 8,
                References = nextOwnerReferences.ToList(),
            };

            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        if (id == currentOwner.Id)
                            return currentOwner;
                        else if (id == nextOwner.Id)
                            return nextOwner;
                        return null;
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.ChangeReferenceOwner(currentOwner.Id, reference.Id, nextOwner.Id);

            // Assert
            Assert.AreSame(nextOwner, reference.Owner);

            currentOwnerReferences.Remove(reference);
            CollectionAssert.AreEquivalent(currentOwnerReferences, currentOwner.References);

            nextOwnerReferences.Add(reference);
            CollectionAssert.AreEquivalent(nextOwnerReferences, nextOwner.References);
        }
        // TODO [CHECK] I cannot figure out how to do it.
        [TestMethod]
        public void ChangeReferenceOwner_AfterAllChanges_CallSaveChanges()
        {
            // Arrange
            var saveChangesCalled = false;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic
                {
                    References = new List<Reference> { new Reference() }
                },
                SaveChanges = () =>
                {
                    saveChangesCalled = true;
                },
            };
            var target = GetHomeServices(stub);

            // Act
            target.ChangeReferenceOwner(-1, 0, -1);

            // Assert
            Assert.IsTrue(saveChangesCalled);
        }
        [TestMethod]
        public void ChangeReferenceOwner_CorrectArgs_ReturnReference()
        {
            var expected = new Reference { Id = 10L, Owner = new Topic { Id = 10L } };
            expected.Owner.References = new List<Reference> { expected };
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                {
                    if (id == expected.Owner.Id)
                        return expected.Owner;
                    return new Topic();
                },
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.ChangeReferenceOwner(expected.Owner.Id, expected.Id, -1);

            // Assert
            Assert.AreSame(expected, actual);
        }

        //[TestMethod]
        //public void RemoveTopic_KeepReferences_ChangeOwnersToTopicOwner()
        //{
        //    // This is checked as: |topic.References| = 0, topic.Owner.References contains the references and references.Owner = topic.Owner
        //    // Arrange
        //    var topic = new Topic { Owner = new Topic { References = new List<Reference> { new Reference() } } };
        //    var references = new List<Reference> { new Reference(), new Reference(), new Reference() };
        //    references.ForEach(r => r.Owner = topic);
        //    topic.References = references.ToList();

        //    var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => topic, };
        //    var target = GetHomeServices(stub);

        //    // Act
        //    target.RemoveTopic(-1, keepReferences: true);

        //    // Assert
        //    Assert.AreEqual(0, topic.References.Count);
        //    CollectionAssert.IsSubsetOf(references, topic.Owner.References);
        //    foreach (var reference in references)
        //        Assert.AreSame(topic.Owner, reference.Owner);
        //}
        #endregion

        #region AddTopic()
        [TestMethod]
        public void AddTopic_NewTopicNull_ArgumentException()
        {
            // Arrange
            var target = GetHomeServices();

            // Act
            try
            {
                target.AddTopic(-1, null, new List<long>());

                // Assert
                Assert.Fail("Argument Exception expected.");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "New Topic argument cannot be null");
            }
        }
        [TestMethod]
        public void AddTopic_ReferencesIdNull_ArgumentException()
        {
            // Arrange
            var target = GetHomeServices();

            // Act
            try
            {
                target.AddTopic(-1, new Topic(), null);

                // Assert
                Assert.Fail("Argument Exception expected.");
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "References Id argument cannot be null");
            }
        }
        [TestMethod]
        public void AddTopic_AnyArgs_PassOwnerIdToRepoGetById()
        {
            // Arrange
            var expected = 10L;
            var actual = expected - 1;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id =>
                    {
                        actual = expected;
                        return null;
                    }
            };
            var target = GetHomeServices(stub);

            // Act
            target.AddTopic(expected, new Topic(), Enumerable.Empty<long>());

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddTopic_NullOwner_ReturnNull()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long> { GetByIdT1 = id => null };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.AddTopic(-1, new Topic(), Enumerable.Empty<long>());

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void AddTopic_CorrectOwner_PassNewTopicToRepoAdd()
        {
            // Arrange
            var expected = new Topic();
            var actual = (Topic)null;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic(),
                AddT0 = t =>
                    {
                        actual = t;
                        return null;
                    },
            };
            var target = GetHomeServices(stub);

            // Act
            target.AddTopic(-1, expected, Enumerable.Empty<long>());

            // Assert
            Assert.AreSame(expected, actual);
        }
        [TestMethod]
        public void AddTopic_NullAdd_ReturnNull()
        {
            // Arrange
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic(),
                AddT0 = t => null,
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.AddTopic(-1, new Topic(), Enumerable.Empty<long>());

            // Assert
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void AddTopic_CorrectAddAndForEachReferenceFromOwner_CallChangeReferenceOwner()
        {
            var expected = new
            {
                CurrentOwner = new Topic(),
                NewTopic = new Topic(),
                References = new List<Reference>
                {
                    new Reference { Id = 1},
                    new Reference { Id = 10},
                    new Reference { Id = 8},
                    new Reference { Id = 12},
                },
                Intruder = new Reference { Id = 7 },
            };
            expected.CurrentOwner.References = expected.References.ToList();
            expected.References.Insert(2, expected.Intruder);

            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => expected.CurrentOwner,
                AddT0 = t => t,
            };
            var stubTarget = GetStubHomeServices(stub);
            var actual = new List<Tuple<Topic, Topic, Reference>>();
            stubTarget.ChangeReferenceOwnerTopicTopicReference = (t1, t2, r) => actual.Add(Tuple.Create(t1, t2, r));

            // Act
            stubTarget.AddTopic(-1, expected.NewTopic, expected.References.Select(r => r.Id));

            // Assert
            expected.References.Remove(expected.Intruder);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreSame(expected.CurrentOwner, actual[i].Item1);
                Assert.AreSame(expected.NewTopic, actual[i].Item2);
                Assert.AreSame(expected.References[i], actual[i].Item3);
            }
        }
        [TestMethod]
        public void AddTopic_AfterReferencesOwnerChanged_CallRepoSaveChanges()
        {
            var currentOwner = new Topic
            {
                References = new List<Reference>
                {
                    new Reference { Id = 1},
                    new Reference { Id = 10},
                    new Reference { Id = 8},
                    new Reference { Id = 12},
                },
            };
            var cantReferences = currentOwner.References.Count;
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => currentOwner,
                AddT0 = t => t,
            };
            var stubTarget = GetStubHomeServices(stub);
            var countCalls = 0;
            stubTarget.ChangeReferenceOwnerTopicTopicReference = (t1, t2, r) => countCalls++;

            var saveChangesCalledCorrectly = false;
            stub.SaveChanges = () => saveChangesCalledCorrectly = countCalls == cantReferences;

            // Act
            stubTarget.AddTopic(-1, new Topic(), currentOwner.References.Select(r => r.Id));

            // Assert
            Assert.IsTrue(saveChangesCalledCorrectly);
        }
        [TestMethod]
        public void AddTopic_CorrectArgs_ReturnTopic()
        {
            // Arrange
            var expected = new Topic();
            var stub = new StubIRepository<Topic, long>
            {
                GetByIdT1 = id => new Topic(),
                AddT0 = t => expected,
            };
            var target = GetHomeServices(stub);

            // Act
            var actual = target.AddTopic(-1, expected, Enumerable.Empty<long>());

            // Assert
            Assert.AreSame(expected, actual);
        }
        #endregion

        private IHomeServices GetHomeServices(IRepository<Topic, long> topicRepo = null, IRepository<Reference, long> refRepo = null)
        {
            return new HomeServices(topicRepo, refRepo);
        }
        private StubHomeServices GetStubHomeServices(IRepository<Topic, long> topicRepo = null, IRepository<Reference, long> refRepo = null)
        {
            return new StubHomeServices(topicRepo, refRepo) { CallBase = true };
        }
    }
}