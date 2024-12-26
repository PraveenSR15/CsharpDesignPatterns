using Prototype;

var manager = new Manager("SR");
var clonedManager = (Manager)manager.Clone(true);
Console.WriteLine($"Manager {clonedManager.Name} was cloned.");

var employee = new Employee("Praveen", clonedManager);
var clonedEmployee = (Employee)employee.Clone(true);
Console.WriteLine($"Employee {clonedEmployee.Name} was cloned under {clonedEmployee.Manager.Name}.");

clonedManager.Name = "Tiger";
Console.WriteLine($"Employee {clonedEmployee.Name} was cloned under {clonedEmployee.Manager.Name}.");

var employee2 = new Employee("Pavi", clonedManager);
var clonedEmployee2 = (Employee)employee2.Clone();
Console.WriteLine($"Employee {clonedEmployee2.Name} was cloned under {clonedEmployee2.Manager.Name}.");

clonedEmployee2.Name = "KuKu";
Console.WriteLine($"Employee {clonedEmployee2.Name} was cloned under {clonedEmployee2.Manager.Name}.");

Console.ReadKey();