﻿namespace Visitor
{
    //public interface IVisitor
    //{
    //    void VisitCustomer(Customer customer);
    //    void VisitEmployee(Employee employee);
    //}
    public interface IVisitor
    {
        void Visit(IElement element);
    }
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; set; }
        public Customer(string name, decimal amountOrdered)
        {
            Name = name;
            AmountOrdered = amountOrdered;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given {Discount}.");
        }
    }
    public class Employee : IElement
    {
        public int YearsEmployed{ get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; set; }
        public Employee(string name, int yearsEmployed)
        {
            Name = name;
            YearsEmployed = yearsEmployed;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given {Discount}.");
        }
    }
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if(element is  Employee employee)
                VisitEmployee(employee);
            else if(element is Customer customer)
                VisitCustomer(customer);
        }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered/10;
            customer.Discount = discount;
            TotalDiscountGiven += discount;
        }
        private void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            employee.Discount = discount;
            TotalDiscountGiven += discount;
        }
    }
    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }
}