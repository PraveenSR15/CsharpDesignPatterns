﻿namespace ClassAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Population { get; private set; }

        public CityFromExternalSystem(string name, string nickname, int population)
        {
            Name = name;
            NickName = nickname;
            Population = population;
        }
    }
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Madurai", "Florida", 300000);
        }
    }

    public class City
    {
        public string FullName { get; private set; }
        public long Population { get; set; }
        public City(string fullName, long population)
        {
            FullName = fullName;
            Population = population;
        }
    }
    public interface ICityAdapter
    {
        City GetCity();
    }
    public class CityAdapter : ExternalSystem, ICityAdapter
    {
        public City GetCity()
        {
            var city = base.GetCity();
            return new City(city.Name + " (Aka) " + city.NickName, city.Population);
        }
    }
}
