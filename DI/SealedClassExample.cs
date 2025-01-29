using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public    class SealedClassExample :   A // : SealedClass this will give error because sealed class can't be inherited
    {
        public SealedClassExample( ) 
        {
            //  base.MyProperty = 100;
              Console.WriteLine("Test Method base property value : " + base.MyProperty);
        }
        public  static  void Test()
        {
            Console.WriteLine("Test Method");
            // base.MyProperty = 100;
        }
    }
    public class A : SealedClass // : SealedClass this will give error because sealed class can't be inherited
    {
        public sealed override void SealedMethod()
        {
            Console.WriteLine("Sealed Method");
        }
        public   sealed  override  int MyProperty { get; set; } = 10 ;  // sealed property
    }

    public   class SealedClass
    {
        public   virtual  int  MyProperty { get; set; } = 10 ;
        public  virtual void SealedMethod()
        {
            Console.WriteLine("Sealed Method");
        }
    }

}