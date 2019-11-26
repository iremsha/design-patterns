using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var audi = new AUDI();
            Console.WriteLine("Car: " + audi.Name);
            Console.WriteLine("Engien from: " + audi.CreatorEngien().MarkManufacturer + " : " + audi.CreatorEngien().Model);
            Console.WriteLine("Interer from: " + audi.CreatorInterer().MarkManufacturer);
            Console.WriteLine("Body from: " + audi.CreatorBody().MarkManufacturer);
        }

        public interface IPartCar
        {
            string MarkManufacturer { get; }

        }
        public interface IEngien : IPartCar
        {
            string Model { get; }
        }

        public interface IBody : IPartCar
        {
            string Type { get; }
        }

        public interface IInterer : IPartCar
        {

        }

        public interface IManufacturer
        {
            string Name { get; }
        }
        public interface IMarkCar : IManufacturer
        {
            IBody CreatorBody();
            IEngien CreatorEngien();
            IInterer CreatorInterer();
        }

        public class Body : IBody
        {
            IManufacturer manufacturer;

            public string MarkManufacturer => manufacturer.Name;
            public string Type => "Sport";

            public Body(IManufacturer _manufacturer)
            {
                manufacturer = _manufacturer;
            }
        }

        public class Engien : IEngien
        {
            IManufacturer manufacturer;
            string IPartCar.MarkManufacturer => manufacturer.Name;
            string IEngien.Model => "v1.8";

            public Engien(IManufacturer _manufacturer)
            {
                manufacturer = _manufacturer;
            }

        }

        public class Interer : IInterer
        {
            IManufacturer manufacturer;
            string IPartCar.MarkManufacturer => manufacturer.Name;

            public Interer(IManufacturer _manufacturer)
            {
                manufacturer = _manufacturer;
            }

        }

        public class EngineElectrical : IManufacturer
        {
            public string Name => "Engine Electrical";
        }

        public class AUDI : IMarkCar
        {
            public string Name => "AUDI";

            public IEngien CreatorEngien() => new Engien(new EngineElectrical());

            public IInterer CreatorInterer() => new Interer(new BMW());

            public IBody CreatorBody() => new Body(this);
        }

        public class BMW : IMarkCar
        {
            public string Name => "BMW";

            public IEngien CreatorEngien() => new Engien(new EngineElectrical());

            public IInterer CreatorInterer() => new Interer(this);

            public IBody CreatorBody() => new Body(new AUDI());
        }
    }
}
