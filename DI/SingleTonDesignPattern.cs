using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{

    public class SingleTonDesignPattern
    {
        private static readonly Lazy<SingleTonDesignPattern> instance = new Lazy<SingleTonDesignPattern>(
            () => new SingleTonDesignPattern()
        );
        public static readonly object lockObj = new object();

        public void DoSomething()
        {
            Console.WriteLine("Do Something");
        }

        private SingleTonDesignPattern()
        {

        }
        public static SingleTonDesignPattern GetInstance => instance.Value;
        // public static SingleTonDesignPattern GetInstance()
        // {
        //     if (instance == null) // first check (not locked)
        //     {
        //         lock (lockObj) // lock ensure that only one thread enters
        //         {
        //             if (instance == null) // second check inside lock 
        //             { instance = new SingleTonDesignPattern(); }
        //         }
        //     }
        //     return instance;
        // }
    }
}