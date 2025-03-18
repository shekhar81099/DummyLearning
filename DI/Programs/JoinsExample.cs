namespace DI.Programs
{
    public class JoinsExample : IPrograms
    {
        public void execute()
        {




            var employees = new List<Employee>        {
                    new Employee { EmployeeId = 1, Name = "Alice" },
            new Employee { EmployeeId = 2, Name = "Bob" },
            new Employee { EmployeeId = 3, Name = "Charlie" }
            };

            var orders = new List<Order>
        {
            new Order { OrderId = 101, EmployeeId = 1, Product = "Laptop" },
            new Order { OrderId = 102, EmployeeId = 2, Product = "Phone" },
            new Order { OrderId = 103, EmployeeId = 1, Product = "Mouse" }
        };

            var d1 = orders.SelectMany(
                emp => employees.Where(b => b.EmployeeId == emp.EmployeeId),
                (emp, ord) => new { emp, ord }
            );
            var employeeOrders = orders.GroupJoin(
                           employees,
                           emp => emp.EmployeeId,   // Outer key: EmployeeId
                           ord => ord.EmployeeId,   // Inner key: EmployeeId
                           (emp, orderGroup) => new
                           {
                               emp,
                               orderGroup
                           });

            string p = System.Text.Json.JsonSerializer.Serialize(d1);
            string p1 = System.Text.Json.JsonSerializer.Serialize(employeeOrders);
            p.Print();
            "\n".Print();
            p1.Print();

            (p == p1).Print();
        }


        // List<Employee> employees = new List<Employee>
        //         {
        //             new Employee { Id = 1, Name = "Alice", Salary = 5000 },
        //             new Employee { Id = 2, Name = "Bob", Salary = 7000 },
        //             new Employee { Id = 3, Name = "Charlie", Salary = 6000 },
        //             new Employee { Id = 4, Name = "David", Salary = 7000 }, // Duplicate max salary
        //             new Employee { Id = 5, Name = "Eve", Salary = 4000 }
        //         };

        // var secondHighestSalary = employees.Where(a => a.Salary >= 1000)
        //     .Select(e => new { Salary = e.Salary, Name = e.Name })
        //     .Distinct()
        //     .OrderByDescending(s => s.Salary)
        //     .Skip(1).FirstOrDefault();
    }
    partial class partialEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }

    class Order
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string Product { get; set; }
    }

}