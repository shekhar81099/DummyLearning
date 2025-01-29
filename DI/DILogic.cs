using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{

    public interface ILoggerDI
    {
        void Log(string message);
    }
    // public int MyProperty { get; set; }

    public interface ILoggerDI1
    {
        void Log(string message)
        {
            Console.WriteLine(message);
        } // Method to be implemented by the logger

    }

    public class ConsoleLogger : ILoggerDI
    {

        // public int MyProperty { get; set; } = 10;// Property to be implemented by the logger
        public void Log(string message)
        {
            Console.WriteLine($"console logger {message}");
        }
    }
    public class FileLogger : ILoggerDI
    {

        // public int MyProperty { get; set; } = 10;// Property to be implemented by the logger
        public void Log(string message)
        {
            Console.WriteLine($"file logger {message}");

        }
    }
    public class UsingCtorDI
    {
        private readonly ILoggerDI _logger;

        public UsingCtorDI(ILoggerDI logger) // Dependency injected here
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Work done!");
        }
    }


    public class UsingPropertyDI
    {
        public ILoggerDI Logger { get; set; } // Dependency injected via property

        public void DoWork()
        {
            Logger?.Log("Work done!");
        }
    }

    public class UsingMethodDI
    {
        public void DoWork(ILoggerDI logger) // Dependency injected as method parameter
        {
            logger.Log("Work done!");
        }
    }

    public abstract class Animal
    {
        public string Name { get; set; } = "Animal";
        public abstract void Speak(); // Abstract method
        public void Eat() => Console.WriteLine("This animal eats food."); // Non-abstract method
    }
    public abstract class Animal1
    {
        public string Name1 { get; set; } = "Animal";
        public abstract void Speak1(); // Abstract method
        public void Eat1() => Console.WriteLine("This animal eats food."); // Non-abstract method
    }
    public class Dog : Animal,    ILoggerDI, ILoggerDI1
    {
        public void Log(string message)
        {
           Console.WriteLine($"{message} hello");
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }

    public class DILogic
    {
        public void Main()
        {


            ILoggerDI logger = new ConsoleLogger();


            UsingCtorDI usingCtorDI = new UsingCtorDI(logger); // method 1
            usingCtorDI.DoWork();

            UsingPropertyDI usingPropertyDI = new UsingPropertyDI // method 2
            {
                Logger = logger // Inject dependency
            };
            usingPropertyDI.DoWork();

            UsingMethodDI usingMethodDI = new UsingMethodDI(); // method 3
            usingMethodDI.DoWork(logger);


        }

        public void AbstractClass()
        {
            Animal dog = new Dog();
            dog.Name = "Dog";
            dog.Speak();
            dog.Eat();
            ILoggerDI dog1 = new Dog(); 
            dog1.Log("hello");

            Animal cat = new Cat();
            cat.Name = "Cat";
            cat.Speak();
            cat.Eat();
        }

    }


}