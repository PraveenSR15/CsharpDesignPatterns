using Visitor;

Container container = new Container();

container.Customers.Add(new Customer("GJ", 500));
container.Customers.Add(new Customer("Loki", 1000));
container.Customers.Add(new Customer("Sophie", 800));
container.Employees.Add(new Employee("SR", 15));
container.Employees.Add(new Employee("Pavi", 5));

DiscountVisitor visitor = new DiscountVisitor();

container.Accept(visitor);

Console.WriteLine($"Total discount : {visitor.TotalDiscountGiven}");

Console.ReadKey();