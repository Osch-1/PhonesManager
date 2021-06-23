using System;
using PhonesManager.Entities.Models;
using PhonesManager.Services;

namespace PhonesManager
{
    class Program
    {
        static GarbageService _service = new();

        static void Main( string[] args )
        {
            string command = "";
            string menu = "1.Create service\n2.Delete service\n3.Find service by id\n4.Find count of services with provided price\n5.Exit";

            while ( command != "5" )
            {
                Console.WriteLine( menu );
                Console.WriteLine( "Enter command: " );
                command = Console.ReadLine();

                Service newService;

                switch ( command )
                {
                    case "1":
                        try
                        {
                            newService = ReadService();
                            _service.CreateService( newService );
                            _service.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine( "An error occured while trying to create service" );
                        }
                        break;
                    case "2":
                        RemoveService();
                        _service.SaveChanges();
                        break;
                    case "3":
                        FindAndPrint();
                        break;
                    case "4":
                        FindAndPrintCountByPrice();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine( "Unknown command\n" );
                        continue;
                }
            }
        }

        private static void FindAndPrintCountByPrice()
        {
            Console.Write( "Enter service price: " );
            string servicePriceStr = Console.ReadLine();
            decimal servicePrice = decimal.Parse( servicePriceStr );

            var serviceWithProvidedPriceCount = _service.GetServicesCountWithPrice( servicePrice );
            Console.WriteLine( $"Total services count: {serviceWithProvidedPriceCount}\n" );
        }

        //))
        private static void FindAndPrint()
        {
            Console.Write( "Enter service id: " );
            string serviceIdStr = Console.ReadLine();
            int serviceId = int.Parse( serviceIdStr );

            Service foundService = _service.GetService( serviceId );
            string res;
            if ( foundService == null )
                res = "Couldn't found service with provided id";
            else
                res = $"Found service info:\nName: {foundService.Name}\nIsActive: {foundService.IsActive}\nDescription: {foundService.Description}\nPrice: {foundService.Price}\n";
            Console.WriteLine( res );
        }

        private static void RemoveService()
        {
            Console.Write( "Enter service id: " );
            string serviceIdStr = Console.ReadLine();
            int serviceId = int.Parse( serviceIdStr );

            Service serviceToRemove = _service.GetService( serviceId );

            if ( serviceToRemove != null )
                _service.RemoveService( serviceToRemove );
        }

        private static Service ReadService()
        {
            Console.Write( "Enter information about a new service (name, isactive, description, price): " );
            var serviceParams = Console.ReadLine();
            var splitedParams = serviceParams.Split( ',' );

            return new Service( splitedParams[ 0 ], bool.Parse( splitedParams[ 1 ] ), splitedParams[ 2 ], decimal.Parse( splitedParams[ 3 ] ) );
        }
    }
}
