internal class Program
{

    private static void Main(string[] args)
    {
        VehicleFactory vehicleFactory = new ConcereteVehicleGermanyFactory();
        VehicleFactory vehicleFactory1 = new ConcereteVehicleKoreaFactory();
        IFactory BMW = vehicleFactory.GetVehicle("BMW");
        BMW.Drive();

        IFactory BENZ = vehicleFactory.GetVehicle("BENZ");
        BENZ.Drive();

        IFactory KIA = vehicleFactory1.GetVehicle("KIA");
        KIA.Drive();

        Console.ReadKey();
    }

    public interface IFactory
    {
        void Drive();
    }

    public class BMW : IFactory
    {
        public void Drive()
        {
            Console.WriteLine("DRIVE BY : BMW");
        }
    }
    public class BENZ : IFactory
    {
        public void Drive()
        {
            Console.WriteLine("DRIVE BY : BENZ");
        }
    }
    public class AUDI : IFactory
    {
        public void Drive()
        {
            Console.WriteLine("DRIVE BY : AUDI");
        }
    }
    public class KIA : IFactory
    {
        public void Drive()
        {
            Console.WriteLine("DRIVE BY : KIA");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string vehicle);
    }
    public class ConcereteVehicleGermanyFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle)
            {
                case "BMW":
                    return new BMW();
                case "BENZ":
                    return new BENZ();
                case "AUDI":
                    return new AUDI();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", vehicle));
            }
        }
    }

    public class ConcereteVehicleKoreaFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle)
            {
                case "KIA":
                    return new KIA();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", vehicle));
            }
        }
    }


}