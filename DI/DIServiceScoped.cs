using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
namespace DI
{


    /// <summary>
    /// Sample service class to understand the concept of DI
    /// </summary>
    public class SampleService
    {
        public Guid Id { get; set ;}
        public SampleService()
        {
            Id = Guid.NewGuid();
        }

    }
    public class Scope
    {
        public IProviders singletonProvider { get; }
        public IProviders transientProvider { get; }
        public IProviders scopedProvider { get; }

        public Scope()
        {
            singletonProvider = new SingletonProvider();
            transientProvider = new TransientProvider();
            scopedProvider = new ScopedProvider();
        }
    }
    public interface IProviders
    {
        public SampleService GetService();
    }

    // this below three interfaces are used to demonstrate the difference between Singleton, Transient and Scoped
    // using microsoft extension dependency injection container
    public interface ISingletonProviders
    {
        public SampleService GetService();
    }
    public interface ITransientProviders
    {
        public SampleService GetService();
    }
    public interface IScopedProviders
    {
        public SampleService GetService();
    }

    public class SingletonProvider : IProviders, ISingletonProviders
    {
        private static SampleService? _service;
        public SingletonProvider()
        {
            _service = new SampleService();
        }


        public SampleService GetService()
        {
            if (_service == null)
            {
                _service = new SampleService();
            }
            return _service;
        }
    }
    public class TransientProvider : ITransientProviders, IProviders
    {


        public SampleService GetService()
        {
            return new SampleService();
        }
    }
    public class ScopedProvider : IScopedProviders, IProviders
    {

        private SampleService _service;
        public ScopedProvider()
        {
            _service = new SampleService();
        }
        public SampleService GetService()
        {
            if (_service == null)
            {
                _service = new SampleService();
            }
            return _service;
        }
    }
    public class MyScopedService : IScopedProviders
    {
        public Guid Id { get; } = Guid.NewGuid();

        public SampleService GetService()
        {
            var ser = new SampleService();
            ser.Id = Id;
            return ser;
        }
    }
    public class DIServiceScoped
    {
        public static void Test()
        {
            Scope scope1 = new Scope();
            Scope scope2 = new Scope();

            // Singleton Example
            WriteLine($"Singleton DI scope1 : {scope1.singletonProvider.GetService().Id} \n ");
            WriteLine($"Singleton DI scope1 : {scope1.singletonProvider.GetService().Id} \n ");
            WriteLine($"Singleton DI scope2 : {scope2.singletonProvider.GetService().Id} \n ");
            WriteLine($"Singleton DI scope2 : {scope2.singletonProvider.GetService().Id} \n ");

            WriteLine();

            // Transient Example
            WriteLine($"Transient DI scope1 {scope1.transientProvider.GetService().Id} \n ");
            WriteLine($"Transient DI scope1 {scope1.transientProvider.GetService().Id} \n ");
            WriteLine($"Transient DI scope2 {scope2.transientProvider.GetService().Id} \n ");
            WriteLine($"Transient DI scope2 {scope2.transientProvider.GetService().Id} \n ");

            WriteLine();

            // Scoped Example
            WriteLine($"Scoped DI scope1 : {scope1.scopedProvider.GetService().Id} \n ");
            WriteLine($"Scoped DI scope1 : {scope1.scopedProvider.GetService().Id} \n ");
            WriteLine($"Scoped DI scope2 : {scope2.scopedProvider.GetService().Id} \n ");
            WriteLine($"Scoped DI scope2 : {scope2.scopedProvider.GetService().Id} \n ");



        }

    }
    /// <summary>
    /// Dependency Injection Container -  Microsoft.Extensions.DependencyInjection used in .NET Core
    /// </summary>
    public static class DIContainer
    {
        public static void Test()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ISingletonProviders, SingletonProvider>();
            services.AddTransient<ITransientProviders, TransientProvider>();
            services.AddScoped<IScopedProviders, ScopedProvider>();

            var serviceProvider = services.BuildServiceProvider();

            var single = serviceProvider.GetRequiredService<ISingletonProviders>();
            var single1 = serviceProvider.GetRequiredService<ISingletonProviders>();
            var single2 = serviceProvider.GetRequiredService<ISingletonProviders>();

            var transient = serviceProvider.GetRequiredService<ITransientProviders>();

            var scoped = serviceProvider.GetRequiredService<IScopedProviders>();

            var scoped1 = serviceProvider.GetRequiredService<IScopedProviders>();



            Console.WriteLine($"Singleton DI : {single.GetService().Id} \n ");
            Console.WriteLine($"Singleton DI : {single1.GetService().Id} \n ");
            Console.WriteLine($"Singleton DI : {single2.GetService().Id} \n ");

            Console.WriteLine($"transient DI : {transient.GetService().Id} \n ");
            Console.WriteLine($"transient DI : {transient.GetService().Id} \n ");
            Console.WriteLine($"transient DI : {transient.GetService().Id} \n ");

            Console.WriteLine($"scoped DI : {scoped.GetService().Id} \n ");
            Console.WriteLine($"scoped DI : {scoped1.GetService().Id} \n ");

            var scoped2 = serviceProvider.GetRequiredService<IScopedProviders>();
            Console.WriteLine($"scoped DI : {scoped2.GetService().Id} \n ");
            // Resolve and use the scoped service
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService1 = scope.ServiceProvider.GetRequiredService<IScopedProviders>();
                Console.WriteLine($"Scoped Service 1 ID: {scopedService1.GetService().Id} \n");
                Console.WriteLine($"Scoped Service 1 ID: {scopedService1.GetService().Id} \n");
                
            }

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService2 = scope.ServiceProvider.GetRequiredService<IScopedProviders>();
                Console.WriteLine($"Scoped Service 2 ID: {scopedService2.GetService().Id}");
            }

        }
    }
}
