using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cab Invoice Generator");
            Ride[] cabRides = { new Ride(5, 10.6), new Ride(6, 10.6) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddUserToDIctionary(001, cabRides, GenerateCabInvoice.RideType.NORMAL);
            rideRepository.AddUserToDIctionary(001, cabRides, GenerateCabInvoice.RideType.PREMIUM);
            rideRepository.AddUserToDIctionary(002, cabRides, GenerateCabInvoice.RideType.PREMIUM);
            //rideRepository.printDict();
            string res = rideRepository.SearchUser(001);
            Console.WriteLine(res);
            
        }
    }
}
