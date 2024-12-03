using Builder;

var garage = new Garage();

var tataBuilder = new TataBuilder();
var skodaBuilder = new SkodaBuilder();

garage.BuildCar(tataBuilder);
garage.ShowCar();

garage.BuildCar(skodaBuilder);
garage.ShowCar();

Console.ReadKey();