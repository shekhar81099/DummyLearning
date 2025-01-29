using DI;

internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // DILogic logger = new DILogic();
        // logger.AbstractClass();
        // new Car(new Engine()).driveCar();

        // DIServiceScoped.Test();
        // DIContainer.Test();
        // HashingPassword.Encrypt();

        // AsyncProgram.Test();

        // UserIPTaskAsyncProgram.Test();
        SealedClassExample sealedClassExample = new SealedClassExample();
        SealedClassExample.Test();
    }
}

public class Car
{

    //  without dependency injection
    // Engine engine = new Engine(); // this is tightly coupled with Engine class 
    // here car class not testable because of tightly coupled with Engine class
    // code is not extendable and maintainable
    // single responsibility principle is not followed
    // lifetime of the object is managed by the car class ( not good practice)


    // with dependency injection
    private Engine engine;
    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public void driveCar()
    {
        engine.start();
        Console.WriteLine("Car is driving");
    }
}

public class Engine
{

    public void start()
    {
        Console.WriteLine("Engine Started");
    }
}