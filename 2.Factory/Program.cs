using System;

namespace ConsoleApp1
{
    public class Program
    {
        public interface ICar
        {
            string Maker { get; }
            string NameModel { get; }
        }

        public interface IPartCar
        {
        }

        public interface ICarEngine : IPartCar
        {
            string Model { get; }
        }

        public interface ICarInterior : IPartCar
        {
        }

        public interface ICarBody : IPartCar
        {
        }

        public interface IManufacturer
        {
            string Name { get; }
        }

        public interface ICarAutomaker : IManufacturer
        {
            string Name { get; }
            void Assemble();
            ICarBody BodyManufacturer();
            ICarEngine EngineManufacturer();
            ICarInterior InteriorManufacturer();
        }

        public class CarBody : ICarBody
        {
            public IManufacturer Manufacturer { get; }

            public CarBody(IManufacturer _Manufacturer)
            {
                Manufacturer = _Manufacturer;
            }
        }

        public class CarEngine : ICarEngine
        {
            public IManufacturer Manufacturer { get; }

            public CarEngine(IManufacturer _Manufacturer)
            {
                Manufacturer = _Manufacturer;
            }

            public string Model => Manufacturer.Name + " 033";
        }

        public class CarInterior : ICarInterior
        {
            public IManufacturer Manufacturer { get; }

            public CarInterior(IManufacturer _Manufacturer)
            {
                Manufacturer = _Manufacturer;
            }
        }

        public class EngineElectrical : IManufacturer
        {
            public string Name => "Engine Electrical";
        }

        public class AUDI : ICarAutomaker
        {
            public string Name => "AUDI";
            public string ModelEngine => EngineManufacturer().Model;

            public void Assemble()
            {
                throw new NotImplementedException();
            }

            public ICarBody BodyManufacturer() => new CarBody(this);

            public ICarEngine EngineManufacturer() => new CarEngine(new EngineElectrical());

            public ICarInterior InteriorManufacturer() => new CarInterior(new BMW());
        }

        public class BMW : ICarAutomaker
        {
            public string Name => "BMW";

            public void Assemble()
            {
                throw new NotImplementedException();
            }

            public ICarBody BodyManufacturer() => new CarBody(this);

            public ICarEngine EngineManufacturer() => new CarEngine(this);

            public ICarInterior InteriorManufacturer() => new CarInterior(this);
        }

        public static void Main(string[] args)
        {
            AUDI myCar = new AUDI();
            Console.WriteLine(myCar.Name);
            Console.WriteLine(myCar.ModelEngine);
        }
    }
}
