using MyIoCPattern;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Samples.MyIoCPattern
{
    public class Sampler : ISampler
    {
        public void ExecuteSample()
        {
            // Register one dog.
            IMyIoCContainer ioc = MySampleIoCContainer.Instance;

            ioc.Register<Animal, Dog>(() =>
            {
                var baufType ="Hello, I'm a singleton!";
                var newDog = new Dog(baufType);
                return newDog;
            });

            // Now I will get all the registered dogs.
            var animalCollection = ioc.GetAllNew<Animal>();
            foreach (var animal in animalCollection)
                Console.WriteLine(animal.MakeNoise());
        }
    }
}