using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace go_hard_like_javascript
{
    delegate void ArrayOfFunc(Func<string> func);
    public static class Useless
    {
        
        public static void TestCars1(Func<string> action)
        {
            Console.WriteLine("\nTestCars1");
            Console.WriteLine("----------");

            Car car1 = new Car();
            car1.DescribeCar();
            Console.WriteLine("----------");


            ConvertibleCar car2 = new ConvertibleCar();
            car2.DescribeCar();
            Console.WriteLine("----------");

            Minivan car3 = new Minivan();
            car3.DescribeCar();
            Console.WriteLine("----------");
            action();
        }


        public static void TestCars2(Func<string> action)
        {
            Console.WriteLine("\nTestCars2");
            Console.WriteLine("----------");

            var cars = new List<Car> { new Car(), new ConvertibleCar(),
                new Minivan() };

            foreach (var car in cars)
            {
                car.DescribeCar();
                Console.WriteLine("----------");
            }
            action();
        }


        public static void TestCars3(Func<string> action)
        {
            Console.WriteLine("\nTestCars3");
            Console.WriteLine("----------");
            ConvertibleCar car2 = new ConvertibleCar();
            Minivan car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
            action();
        }


        public static void TestCars4(Func<string> action)
        {
            Console.WriteLine("\nTestCars4");
            Console.WriteLine("----------");
            Car car2 = new ConvertibleCar();
            Car car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
            action();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            ArrayOfFunc funcFabric = null;
            MethodInfo[] methodInfos = typeof(Useless)
                          .GetMethods(BindingFlags.Static | BindingFlags.Public);

            foreach (var method  in methodInfos) funcFabric += (ArrayOfFunc) Delegate.CreateDelegate(typeof(ArrayOfFunc), method, false);
            
            funcFabric.Invoke(Console.ReadLine);  
               
        }

       
    }


    class Car
    {
        public virtual void DescribeCar()
        {
            Console.WriteLine("Four wheels and an engine.");
            ShowDetails();
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine("Standard transportation.");
        }
    }


    class ConvertibleCar : Car
    {
        public new void ShowDetails()
        {
            Console.WriteLine("A roof that opens up.");
        }
    }

    // Class Minivan uses the override modifier to specify that ShowDetails  
    // extends the base class method.  
    class Minivan : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Carries seven people.");
        }
    }
}
