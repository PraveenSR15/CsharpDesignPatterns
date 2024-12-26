using Command;

CommandManager commandManager = new();
EmployeeManagerRepository repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeManagerList(repository,1,new Employee("Kandhasami",1)));
repository.WriteDataStore();
commandManager.Undo();
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeManagerList(repository, 1, new Employee("Ramasami", 2)));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeManagerList(repository, 2, new Employee("Madasami", 3)));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeManagerList(repository, 2, new Employee("Kuppusami", 4)));
repository.WriteDataStore();

//Duplicate data
commandManager.Invoke(new AddEmployeeManagerList(repository, 2, new Employee("Kuppusami", 4)));
repository.WriteDataStore();
commandManager.UndoAll();
repository.WriteDataStore();

Console.ReadKey();