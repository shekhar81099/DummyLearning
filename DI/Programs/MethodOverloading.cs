using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Programs
{
    public class GrandParent
    {
        public int Add1() => 1.Print();
    }
    public class Parent : GrandParent
    {
        public new int Add1() => 5.Print();

        // public int CallGrandParentMethod() => base.Add1();
    }
    public class MethodOverloading : IPrograms
    {
        public MethodOverloading()
        {

        }
        public delegate void Act();
        public delegate int Fun();
        public int Add1() => 10.Print();
        public void Adds() => 100.Print();
        public void execute()
        {
            MethodOverloading methodOverloading = new MethodOverloading();
            Parent parent = new Parent();

            // methodOverloading.Add(5, 3);
            // parent.CallGrandParentMethod();

            // explicitly casting to Grandparent() 
            // ((GrandParent)parent).Add1();
            // ((Parent)parent).Add1();

            // GrandParent p1 = new Parent();
            // p1.Add1();
            Func<int, int, int> add = (x, y) => x * y;
            Action<int, int, int> adds = (a, b, c) => (a + b + c).Print();

            // add(5, 5).Print();
            // adds(1, 1, 1);
            // Act act = new Act(() => 500.Print());
            // Fun fn = new Fun(() => 500);
            // var p = fn.Invoke().Print();
            // p.Print();

            // act.Invoke();
        }

        // public int Add(int a, int b) => a + b;
        // public int Add(int a, int b, int c) => (a + b + c);
    }
}