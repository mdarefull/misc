using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyIoCPattern;
using Samples.MyIoCPattern;
using System.Linq;

namespace Testings.MyIoCPattern
{
    [TestClass]
    public class MySampleIoCContainerUnitTest
    {
        [TestCleanup]
        public void ResetContainer()
        {
            GetClassUnderTest().Reset();
        }

        #region 1 - Singleton
        #region The container should implement a singleton pattern.
        // We shouldn't test the singleton pattern because it is a world-wide pattern that every body should know so it would be
        //  enough to check it by eye.
        // With that being said, I've include these test with the sole purpose of having a proof of concept of how a singleton
        //  class should behave.
        [TestMethod]
        [TestCategory("Singleton")]
        [Description("Invokes the Instance's getter in order to check that it successfully retrieves an Instance of MySampleIoCContainer.")]
        [Owner("Roberto Santana Perdomo")]
        public void Instance_InvokeProperty_ReturnsMySampleIoCContainerInstance()
        {
            var ioc = MySampleIoCContainer.Instance;

            Assert.IsNotNull(ioc);
            Assert.IsInstanceOfType(ioc, typeof(MySampleIoCContainer));
        }

        [TestMethod]
        [TestCategory("Singleton")]
        [Description("Ensure that multiple calls to the Instance's getter returns the same object.")]
        [Owner("Roberto Santana Perdomo")]
        public void Instance_InvokesInstanceMultipleTimes_ReturnsSameInstance()
        {
            MySampleIoCContainer instance1 = MySampleIoCContainer.Instance;
            MySampleIoCContainer instance2 = MySampleIoCContainer.Instance;

            Assert.AreSame(instance1, instance2);
        }
        #endregion
        #endregion

        #region 2 - Registering Instances
        #region d - Register a new concrete type for a base type by providing its instantiation logic.
        // We would only test for the "not ensured" features, that is to say, we shouldn't test for 2.a - 2.c because they
        // are ensures at build time.

        // The registering method are a few superficial ones becuase they do not tested if the instance was indeed registered.
        // They just tested the stability of the Register Method.
        [TestMethod]
        [TestCategory("Registering Instances_d")]
        [Description(@"Register one dog. This step is expected to not generate any exception.")]
        [Owner("Roberto Santana Perdomo")]
        public void Register_RegisterNewType_NonExceptionOccurred()
        {
            var ioc = GetClassUnderTest();

            var dog = new Dog("Unit test dog.");
            try
            {
                ioc.Register<Animal, Dog>(() => dog);
            }
            catch (Exception e)
            {
                Assert.Fail("An unexpected exception has been thrown:\n {0}", e);
            }
        }
        #endregion
        #region e - Multiple instantiation logic can be registered for the same types.
        // Because we have already tested the Register method, now we can freely use our helper method.
        [TestMethod]
        [TestCategory("Registering Instances_e")]
        [Description(@"Register 10 dogs. This step is expected to not generate any exception.")]
        [Owner("Roberto Santana Perdomo")]
        public void Register_RegisterMultipleTypes_NonExceptionOccurred()
        {
            try
            {
                RegisterAnimals(10);
            }
            catch (Exception e)
            {
                Assert.Fail("An unexpected exception has been thrown:\n {0}", e);
            }
        }
        #endregion
        #region f - Allow the user to forbid further registering
        [TestMethod]
        [TestCategory("Registering Instances_f")]
        [Description(@"Ensure that an InvalidOperationException arise when trying to register instance after a call to EndRegistering().")]
        [Owner("Roberto Santana Perdomo")]
        public void EndRegistering_TryingToRegisterAfterCallingMethod_InvalidOperationException()
        {
            GetClassUnderTest().EndRegistering();

            try
            {
                RegisterAnimals();
                Assert.Fail("Expected Exception: InvalidOperationException not found");
            }
            catch (InvalidOperationException) { }
        }
        #endregion
        #region h - Allow the user to reset the container.
        [TestMethod]
        [TestCategory("Registering Instances_h")]
        [Description(@"Register one animal, reset the container and check that no animals exists.")]
        [Owner("Roberto Santana Perdomo")]
        public void Reset_ExecuteMethod_IsEmpty()
        {
            var ioc = GetClassUnderTest();
            RegisterAnimals();
            ioc.Reset();

            var animal = ioc.GetAny<Animal>();
            Assert.IsNull(animal, "The container has been reseted, it should be empty.");
        }
        [TestMethod]
        [TestCategory("Registering Instances_h")]
        [Description(@"Terminate the registration period, reset the container and check that registering animals is allowed.")]
        [Owner("Roberto Santana Perdomo")]
        public void Reset_ExecuteMethod_AllowRegistering()
        {
            var ioc = GetClassUnderTest();
            ioc.EndRegistering();
            ioc.Reset();

            try
            {
                RegisterAnimals();
            }
            catch (NotSupportedException)
            {
                Assert.Fail("The container has been reseted, it should allow registering instances again.");
            }
        }
        #endregion
        #endregion

        #region 3 - Retrieving Types
        #region a - Retrieve all instances for a given type.
        [TestMethod]
        [TestCategory("Retrieving Types_a")]
        [Description(@"Register 3 animals. Retrieve them. Check if the retrieved amount is 3.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_Register3AnimalsAndRetrieveThem_RetrievedAmountEqual3()
        {
            RegisterAnimals(3);

            var ioc = GetClassUnderTest();
            var animals = ioc.GetAll<Animal>().ToList();
            Assert.AreEqual<int>(3, animals.Count,
                  "3 animals have been registered and {0} have been retrieved.", animals.Count);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_a")]
        [Description(@"Register 3 animals. Retrieve them twice. Check if for both sets the animals are the same.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_Register3AnimalsAndRetrieveThemTwice_BothListAreSame()
        {
            RegisterAnimals(3);

            var ioc = GetClassUnderTest();
            var animals1 = ioc.GetAll<Animal>().ToList();
            var animals2 = ioc.GetAll<Animal>().ToList();
            Assert.AreEqual<int>(animals1.Count, animals2.Count,
                     "{0} animals were retrieved the first time, {1} were retrived the second", animals1.Count, animals2.Count);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreSame(animals1[i], animals2[i],
                    "The {0}-th animal from the first set: {1} is not the same than the one in the second set: {2}", i, animals1[i], animals2[i]);
            }
        }
        #endregion
        #region b - Retrieve all new instances for a given type.
        [TestMethod]
        [TestCategory("Retrieving Types_b")]
        [Description(@"Register 3 animals. Retrieve new instances of them. Check if the retrieved amount is 3.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register3AnimalsAndRetrieveNewInstances_RetrievedAmountEqual3()
        {
            var ioc = GetClassUnderTest();
            RegisterAnimals(3);

            var animals1 = ioc.GetAllNew<Animal>().ToList();
            Assert.AreEqual<int>(3, animals1.Count,
                  "3 animals have been registered and {0} have been retrieved.", animals1.Count);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_b")]
        [Description(@"Register 3 animals. Retrieve new instances of them twice. Check if for both sets the animals are disjunts.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register3AnimalsAndRetrieveNewInstancesTwice_BothSetsAreDisjunt()
        {
            var ioc = GetClassUnderTest();
            RegisterAnimals(3);

            var animals1 = ioc.GetAllNew<Animal>().ToList();
            var animals2 = ioc.GetAllNew<Animal>().ToList();
            Assert.AreEqual<int>(animals1.Count, animals2.Count,
                     "{0} animals were retrieved the first time, {1} were retrived the second", animals1.Count, animals2.Count);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreNotSame(animals1[i], animals2[i],
                        "The {0} animal from the first set: {1} is contained on the second set", i, animals1[i]);
        }
        #endregion
        #region c - Retrieve one (any) instance for a given type
        [TestMethod]
        [TestCategory("Retrieving Types_c")]
        [Description(@"Register 1 animal. Retrieve it twice. Check if both animals are the same.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAny_Register1AnimalAndRetrieveTwice_BothAnimalsAreSame()
        {
            RegisterAnimals();

            var ioc = GetClassUnderTest();
            var animal1 = ioc.GetAny<Animal>();
            var animal2 = ioc.GetAny<Animal>();

            Assert.AreSame(animal1, animal2,
                "The animal {0} is not the same as the animal {1}", animal1, animal2);
        }
        #endregion
        #region d - Retrieve one (any) new instance for a given type
        [TestMethod]
        [TestCategory("Retrieving Types_d")]
        [Description(@"Register 1 animal. Retrieve it twice. Check if both animals are NOT the same.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Register1AnimalAndRetrieveTwice_BothAnimalAreNotSame()
        {
            RegisterAnimals();

            var ioc = GetClassUnderTest();
            var animal1 = ioc.GetAnyNew<Animal>();
            var animal2 = ioc.GetAnyNew<Animal>();

            Assert.AreNotSame(animal1, animal2,
                "The animal {0} is the same as the animal {1}", animal1, animal2);
        }
        #endregion
        #region e - The retrieved instance should belongs to a registered type
        [TestMethod]
        [TestCategory("Retrieving Types_e")]
        [Description(@"Register 1 dog. GetAll dogs. Check if the retrieved instance is of type dog.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_Register1DogAndRetrieveIt_RetrievedAnimalIsOfTypeDog()
        {
            var ioc = GetClassUnderTest();
            ioc.Register<Animal, Dog>(() => new Dog("I'm a dog!"));

            var animals = ioc.GetAll<Animal>();
            foreach (var dog in animals)
                Assert.IsInstanceOfType(dog, typeof(Dog),
                    "The animal {0} is not of type Dog, is of type {1}", dog, dog.GetType().FullName);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_e")]
        [Description(@"Register 1 dog. GetAllNew dogs. Check if the retrieved instance is of type dog.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register1DogAndRetrieveIt_RetrievedAnimalIsOfTypeDog()
        {
            var ioc = GetClassUnderTest();
            ioc.Register<Animal, Dog>(() => new Dog("I'm a dog!"));

            var animals = ioc.GetAllNew<Animal>().ToList();
            foreach (var dog in animals)
                Assert.IsInstanceOfType(dog, typeof(Dog),
                    "The animal {0} is not of type Dog, is of type {1}", dog, dog.GetType().FullName);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_e")]
        [Description(@"Register 1 dog. GetAny dog. Check if the retrieved instance is of type dog.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAny_Register1DogAndRetrieveIt_RetrievedAnimalIsOfTypeDog()
        {
            var ioc = GetClassUnderTest();
            ioc.Register<Animal, Dog>(() => new Dog("I'm a dog!"));

            var dog = ioc.GetAny<Animal>();
            Assert.IsInstanceOfType(dog, typeof(Dog),
                "The animal {0} is not of type Dog, is of type {1}", dog, dog.GetType().FullName);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_e")]
        [Description(@"Register 1 dog. GetAnyNew dog. Check if the retrieved instance is of type dog.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Register1DogAndRetrieveIt_RetrievedAnimalIsOfTypeDog()
        {
            var ioc = GetClassUnderTest();
            ioc.Register<Animal, Dog>(() => new Dog("I'm a dog!"));

            var dog = ioc.GetAnyNew<Animal>();
            Assert.IsInstanceOfType(dog, typeof(Dog),
                "The animal {0} is not of type Dog, is of type {1}", dog, dog.GetType().FullName);
        }
        #endregion
        #region f - When retrieving one instance, if none such instance has been found, a null value should be returned.
        [TestMethod]
        [TestCategory("Retrieving Types_f")]
        [Description(@"Container is fresh. Try to retrieve any animal. Null should have been returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAny_Retrieve1Animal_NullReturned()
        {
            var ioc = GetClassUnderTest();
            var animal = ioc.GetAny<Animal>();

            Assert.IsNull(animal,
                "Whith an empty container, {0} has been returned.", animal);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_f")]
        [Description(@"Register 3 animals. Try to retrieve a String. Null should have been returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAny_Register3AnimalsAndRetrieveString_NullReturned()
        {
            RegisterAnimals(3);
            var ioc = GetClassUnderTest();
            var @string = ioc.GetAny<String>();

            Assert.IsNull(@string,
                "With a container full of animals, the String {0} has been returned", @string);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_f")]
        [Description(@"Container is fresh. Try to retrieve any new animal. Null should have been returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Retrieve1Animal_NullReturned()
        {
            var ioc = GetClassUnderTest();
            var animal = ioc.GetAnyNew<Animal>();

            Assert.IsNull(animal,
                "With an empty container, {0} has been returned", animal);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_f")]
        [Description(@"Register 3 animals. Try to retrieve a String. Null should have been returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Register3AnimalsAndRetrieveString_NullReturned()
        {
            RegisterAnimals(3);
            var ioc = GetClassUnderTest();
            var @string = ioc.GetAnyNew<String>();

            Assert.IsNull(@string,
                "With a container full of animals, the String {0} has been returned", @string);
        }
        #endregion
        #region h - When retrieving all the instances, if none such instances has been found an empty collecion should be returned.
        [TestMethod]
        [TestCategory("Retrieving Types_h")]
        [Description(@"Container is fresh. Try to retrieve all animals. An empty IEnumerable should be returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_RetrieveAnimals_EmtpyEnumerableReturned()
        {
            var ioc = GetClassUnderTest();
            var animals = ioc.GetAll<Animal>().ToList();

            Assert.AreEqual<int>(0, animals.Count,
                "With an empty container, {0} animals has been returned", animals.Count);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_h")]
        [Description(@"Register 3 animals. Try to retrieve all Strings. An empty IEnumerable should be returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_Register3AnimalsAndRetrieveAllStrings_EmtpyEnumerableReturned()
        {
            RegisterAnimals(3);

            var ioc = GetClassUnderTest();
            var animals = ioc.GetAll<String>().ToList();

            Assert.AreEqual<int>(0, animals.Count,
                "With an empty container, {0} animals has been returned", animals.Count);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_h")]
        [Description(@"Container is fresh. Try to retrieve all new animals. An empty IEnumerable should be returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_RetrieveAnimals_EmtpyEnumerableReturned()
        {
            var ioc = GetClassUnderTest();
            var animals = ioc.GetAllNew<Animal>().ToList();

            Assert.AreEqual<int>(0, animals.Count,
                "With an empty container, {0} animals has been returned", animals.Count);
        }
        [TestMethod]
        [TestCategory("Retrieving Types_h")]
        [Description(@"Register 3 animals. Try to retrieve all new Strings. An empty IEnumerable should be returned.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register3AnimalsAndRetrieveAllStrings_EmtpyEnumerableReturned()
        {
            RegisterAnimals(3);

            var ioc = GetClassUnderTest();
            var animals = ioc.GetAllNew<String>().ToList();

            Assert.AreEqual<int>(0, animals.Count,
                "With an empty container, {0} animals has been returned", animals.Count);
        }
        #endregion
        #endregion

        #region 4 - Instances
        #region a - The new instances should be created at request time and then returned.
        [TestMethod]
        [TestCategory("Instances_a")]
        [Description(@"Create 3 mock instantiation logics for 3 dogs. Register the 3 dogs and retrieve them all new. Every mock should be executed.
                        The mock test should be that every single instantiation logic should have been call on the GetAllNew call")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register3MockDogsAndRetrieveAll_AllInstantiatioLogicsExecuted()
        {
            var mockFlags = new bool[3];
            var ioc = GetClassUnderTest();

            Action<int> RegisterDog = index =>
                {
                    ioc.Register<Animal, Dog>(() =>
                        {
                            mockFlags[index] = true;
                            return new Dog("Mock Dog " + index);
                        });
                };
            for (int i = 0; i < 3; i++)
                RegisterDog(i);

            for (int i = 0; i < 3; i++)
                mockFlags[i] = false;
            ioc.GetAllNew<Animal>().ToList();
            for (int i = 0; i < 3; i++)
                Assert.IsTrue(mockFlags[i],
                    "The {0} i-th execution logic hasn't been executed", i);
        }
        [TestMethod]
        [TestCategory("Instances_a")]
        [Description(@"Create 3 mock instantiation logics for 3 dogs. Register the 3 dogs and retrieve any of them new. Exactly one mock should be executed.
                        The mock test should be that exactly one instantiation logic should have been call on the GetAnyNew call")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Register3MockDogsAndRetrieveAny_AllInstantiatioLogicsExecuted()
        {
            Boolean mockFlag = false;
            var ioc = GetClassUnderTest();

            for (int i = 0; i < 3; i++)
                ioc.Register<Animal, Dog>(() =>
                    {
                        mockFlag = true;
                        return new Dog("Mock Dog");
                    });

            mockFlag = false;
            ioc.GetAnyNew<Animal>();
            Assert.IsTrue(mockFlag, "None instantiation logic has been called");
        }
        [TestMethod]
        [TestCategory("Instances_a")]
        [Description(@"Create 3 mock instantiation logics for 3 dogs. Register the 3 dogs and retrieve them all new. The returned instance should be the same as the returned from every mock.
                        The mock test should be that every single instantiated instance should have been the same as in the returned collection.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAllNew_Register3MockDogsAndRetrieveAll_InstantiatedInstacesReturned()
        {
            var mockObjects = new Dog[3];
            var ioc = GetClassUnderTest();

            Action<int> RegisterDog = index =>
            {
                ioc.Register<Animal, Dog>(() =>
                {
                    return mockObjects[index] = new Dog("Mock Dog " + index);
                });
            };
            for (int i = 0; i < 3; i++)
                RegisterDog(i);

            for (int i = 0; i < 3; i++)
                mockObjects[i] = null;
            var animals = ioc.GetAllNew<Animal>().ToList();

            foreach (var mock in mockObjects)
                CollectionAssert.Contains(animals, mock,
                    "The {0} instantiated object is not contained inside the retrieved collection", mock);
        }
        [TestMethod]
        [TestCategory("Instances_a")]
        [Description(@"Create 3 mock instantiation logics for 3 dogs. Register the 3 dogs and retrieve any new. The returned instance should be the same as the retrieved.
                        The mock test should be that the instantiated instance should have been the same as the returned instance.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAnyNew_Register3MockDogsAndRetrieveAny_InstantiatedInstaceReturned()
        {
            Dog mockObject;
            var ioc = GetClassUnderTest();
            for (int i = 0; i < 3; i++)
                ioc.Register<Animal, Dog>(() =>
                {
                    return mockObject = new Dog("Mock Dog");
                });

            mockObject = null;
            var animal = ioc.GetAnyNew<Animal>();

            Assert.AreSame(mockObject, animal,
                "The {0} instantiated dog is not the same as the retrieved one", mockObject);
        }
        #endregion
        #region b - The singleton instances should be created at registered time and returned in every request.
        [TestMethod]
        [TestCategory("Instances_b")]
        [Description(@"Create 3 mocks instantiation logics for 3 dogs. Register the 3 dogs. Every mock should be executed at registering time.
                        The mock test should be that every single instantiation logic should have been call on the Register call")]
        [Owner("Roberto Santana Perdomo")]
        public void Register_Register3MockDogs_AllInstantiatioLogicsExecuted()
        {
            var mockFlags = new bool[3] { false, false, false };
            var ioc = GetClassUnderTest();
            for (int i = 0; i < 3; i++)
            {
                ioc.Register<Animal, Dog>(() =>
                {
                    mockFlags[i] = true;
                    return new Dog("Mock Dog " + i);
                });

                Assert.IsTrue(mockFlags[i],
                    "The {0} i-th execution logic hasn't been executed", i);
            }
        }
        [TestMethod]
        [TestCategory("Instances_b")]
        [Description(@"Create 3 mocks instantiation logics for 3 dogs. Register the 3 dogs and retrieve them all. Every returned instance should be the same as the created at registering time.
                        The mock test should be that every single instance returned should be the same as the created at registering time.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAll_Register3MockDogsAndRetrieveThem_InstantiatedInstancesReturned()
        {
            var mockObjects = new Dog[3];
            var ioc = GetClassUnderTest();
            Action<int> RegisterDog = index =>
            {
                ioc.Register<Animal, Dog>(() =>
                {
                    var dog = new Dog("Mock Dog " + index);
                    if (mockObjects[index] == null)
                        mockObjects[index] = dog;
                    return dog;
                });
            };
            for (int i = 0; i < 3; i++)
                RegisterDog(i);

            var animals = ioc.GetAll<Animal>().ToList();
            foreach (var mock in mockObjects)
                CollectionAssert.Contains(animals, mock,
                    "The {0} instantiated object is not contained inside the retrieved collection", mock);
        }
        [TestMethod]
        [TestCategory("Instances_b")]
        [Description(@"Create 3 mocks instantiation logics for 3 dogs. Register the 3 dogs and retrieve any new. The returned instance should be the same as the retrieved.
                        The mock test should be that the instantiated instance should have been the same as the returned instance.")]
        [Owner("Roberto Santana Perdomo")]
        public void GetAny_Register3MockDogsAndRetrieveAny_InstantiatedInstaceReturned()
        {
            Dog mockObject = null;
            var ioc = GetClassUnderTest();
            for (int i = 0; i < 3; i++)
                ioc.Register<Animal, Dog>(() =>
                {
                    var dog = new Dog("Mock Dog");
                    if (mockObject == null)
                        mockObject = dog;
                    return mockObject = dog;
                });

            var animal = ioc.GetAnyNew<Animal>();
            Assert.AreSame(mockObject, animal,
                "The {0} instantiated dog is not the same as the retrieved one", mockObject);
        }
        #endregion
        #endregion

        #region Helpers
        private void RegisterAnimals(int times = 1)
        {
            var ioc = MySampleIoCContainer.Instance;
            var rnd = new Random();
            for (int i = 0; i < times; i++)
                ioc.Register<Animal, Dog>(() => new Dog(rnd.Next().ToString()));
        }
        // This method allows me to port the tests for testing multiple implementations without having to change any test code.
        // Because these are Unit Test, these method should never be changed for a given test. 
        //  I.e: Instead of changing this method for testing multiple implementations, we should have one class for every
        //      implementation under test. Now, because this method, we can create those classes pretty simple, just
        //      by copying-pasting this class and then changing the returned specific instance. But we should never have
        //      one test class like: IMyIoCContainerTest or anything generic like that.
        private IMyIoCContainer GetClassUnderTest()
        {
            return MySampleIoCContainer.Instance;
        }
        #endregion
    }
}