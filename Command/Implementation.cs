namespace Command
{
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(string name,int id)
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
        void AddEmployee(int managerId,Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId,int employeeId);
        void WriteDataStore();
    }
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {

        private List<Manager> _managers = new() { new Manager("Pavi",1),new Manager("SR",2)};
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
            foreach(var manager in _managers)
            {
                Console.WriteLine($"Manager: {manager.Name}");
                if(manager.Employees.Any())
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

    public class AddEmployeeManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private readonly int _managerId;
        private readonly Employee? _employee;

        public AddEmployeeManagerList(IEmployeeManagerRepository repository, int managerId, Employee employee)
        {
            _employeeManagerRepository = repository;
            _managerId = managerId;
            _employee = employee;
        }
        public bool CanExecute()
        {
            if(_employee == null)
                return false;
            if(_employeeManagerRepository.HasEmployee(_managerId,_employee.Id))
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
        private readonly Stack<ICommand> _commands = new();
        public void Invoke(ICommand command)
        {
            if(command.CanExecute())
            {
                command.Execute();
                _commands.Push(command);
            }
        }
        public void Undo()
        {
            if ((_commands.Any()))
            {
                _commands.Pop()?.Undo();
            }
        }

        public void UndoAll()
        {
            while(_commands.Any())
                _commands.Pop().Undo();
        }
    }
}
