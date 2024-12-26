namespace Memento
{
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees { get; set; } = new();
        public Manager(string name, int id) : base(name, id)
        {
        }
    }

    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {

        private List<Manager> _managers = new() { new Manager("Pavi", 1), new Manager("SR", 2) };
        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Add(employee);
        }
        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(x => x.Id == managerId).Employees.Any(x => x.Id == employeeId);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager: {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id} - {employee.Name}.");
                    }
                }
                else
                {
                    Console.WriteLine("No Employees");
                }
            }
        }
    }

    public interface ICommand
    {
        bool CanExecute();
        void Execute();
        void Undo();
    }

    public class AddEmployeeManagerListMemento
    {
        public readonly int ManagerId;
        public readonly Employee? Employee;
        public AddEmployeeManagerListMemento(int managerId, Employee? employee)
        {
            Employee = employee;
            ManagerId = managerId;
        }
    }

    public class AddEmployeeManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee? _employee;

        public AddEmployeeManagerList(IEmployeeManagerRepository repository, int managerId, Employee? employee)
        {
            _employeeManagerRepository = repository;
            _managerId = managerId;
            _employee = employee;
        }
        public AddEmployeeManagerListMemento CreateMemento()
        {
            return new AddEmployeeManagerListMemento(_managerId, _employee);
        }
        public void RestoreMemento(AddEmployeeManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }
        public bool CanExecute()
        {
            if (_employee == null)
                return false;
            if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
                return false;

            return true;
        }

        public void Execute()
        {
            if (_employee == null)
                return;
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }
        public void Undo()
        {
            if (_employee == null)
                return;
            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }
    }

    public class CommandManager
    {
        private readonly Stack<AddEmployeeManagerListMemento> _mementos = new();
        private AddEmployeeManagerList? _command;
        public void Invoke(ICommand command)
        {
            if (_command == null)
                _command = (AddEmployeeManagerList)command;
            if (command.CanExecute())
            {
                command.Execute();
                _mementos.Push(((AddEmployeeManagerList)command).CreateMemento());
            }
        }
        public void Undo()
        {
            if ((_mementos.Any()))
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }

        public void UndoAll()
        {
            while (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }
    }
}
