namespace DI
{
    interface St1
    {
        public int MyProperty() => 55;
    }
    struct NewStruct
    {
        public int MyProperty1 { get; set; }
        public string Name;
        public int Age;
        public int MyProperty() { return 500; }

    }

    public class Test
    {
        public Test()
        {
            NewStruct p1 = new();
            p1.Name = "Raman";
            p1.Age = 12;
            p1.MyProperty1 = 505;
            p1.MyProperty();

            Res a = Res.bd; 
            a.Print() ;
            ((int)a).Print() ;

        }

    }

    public enum Res
    {
        a = 1,
        bs = 5,
        bd = 2,
        bdq = 3,

    }
}