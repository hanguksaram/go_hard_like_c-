using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace go_hard_like_javascript
{
    class Program
    {
        delegate void ArrayOfFunc(Func<string> func);
        static void Main(string[] args)
        {

            ArrayOfFunc test1, test2, test3, test4, test5;

            test1 = TestCars1;
            test2 = TestCars2;
            test3 = TestCars3;
            test4 = TestCars4;
            test5 = test1 + test2 + test3 + test4;
        
            test5.Invoke(Console.ReadLine);
            
         }

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
