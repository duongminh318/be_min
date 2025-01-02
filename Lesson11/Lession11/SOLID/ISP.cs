using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11.SOLID
{
    public interface IAnimal
    {
        public void Fly();
        public void Swim();
        public void Run();
    }

    public class Dog : IAnimal
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("Allow run");
        }

        public void Swim()
        {
            Console.WriteLine("Allow swim");
        }
    }

    public interface IFlyAble
    { 
        public void Fly(); 
    }
    public interface IRunAble
    {
        public void Run();
    }
    public interface ISwimAble
    {
        public void Swim();
    }


    public class Dog1 : ISwimAble, IRunAble
    {
        public void Run()
        {
            Console.WriteLine("Allow run");
        }

        public void Swim()
        {
            Console.WriteLine("Allow swim");
        }
    }
}
