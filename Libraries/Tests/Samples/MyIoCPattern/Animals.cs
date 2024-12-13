using System;

namespace Samples.MyIoCPattern
{
    public abstract class Animal
    {
        private readonly string _name;

        public Animal()
        {
            _name = Guid.NewGuid().ToString();
        }
        public virtual string MakeNoise()
        {
            return _name + " : ";
        }
    }
    public class Dog : Animal
    {
        private readonly string _baufType;

        public Dog(string baufType)
        {
            _baufType = baufType;
        }
        public override string MakeNoise()
        {
            return base.MakeNoise() + _baufType;
        }
    }
}