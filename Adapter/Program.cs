using ClassAdapter;

var cityAdapter = new CityAdapter();
var city =  cityAdapter.GetCity();

Console.WriteLine($"The city {city.FullName} has a population of {city.Population} people.");
Console.ReadKey();