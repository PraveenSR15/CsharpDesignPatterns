using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var part in _parts)
            {
                stringBuilder.Append($"The part {part} has been added to {_carType} Car.\n");
            }
            return stringBuilder.ToString();
        }
    }

    public abstract class CarBuilder
    {
        public Car Car { get; private set; }
        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }
        public abstract void BuildEngine();
        public abstract void BuildFrame();
        public abstract void BuildAudio();
        public abstract void BuildAC();
    }

    public class TataBuilder : CarBuilder
    {
        public TataBuilder() : base("Tata Altroz")
        {
            
        }
        public override void BuildAC()
        {
            Car.AddPart("6 AC");
        }

        public override void BuildAudio()
        {
            Car.AddPart("5.1 Dolby");
        }

        public override void BuildEngine()
        {
            Car.AddPart("1.5 Litre");
        }

        public override void BuildFrame()
        {
            Car.AddPart("Metal Frame");
        }
    }

    public class SkodaBuilder : CarBuilder
    {
        public SkodaBuilder() : base("Skoda Kylaq")
        {
            
        }
        public override void BuildAC()
        {
            Car.AddPart("6 AC");
        }

        public override void BuildAudio()
        {
            Car.AddPart("7.1 Dolby Surround");
        }

        public override void BuildEngine()
        {
            Car.AddPart("1.5 Litre TSI");
        }

        public override void BuildFrame()
        {
            Car.AddPart("Premier Metallic");
        }
    }

    public class Garage
    {
        private CarBuilder? _carBuilder;
        public Garage()
        {
            
        }

        public void BuildCar(CarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
            _carBuilder.BuildEngine();
            _carBuilder.BuildFrame();
            _carBuilder.BuildAC();
            _carBuilder.BuildAudio();
        }

        public void ShowCar()
        {
            Console.WriteLine(_carBuilder?.Car.ToString());
        }
    }
}
