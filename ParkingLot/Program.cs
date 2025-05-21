
using System;
using ParkingLot;
internal class Program
{
    public static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        List<ParkingTicket> parkingTickets = new List<ParkingTicket>();
        int exitCode = 1;

        //initialize parking lot 
        Console.WriteLine("Enter the number of bike slots:");
        int bikeSlots = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of car slots:");
        int carSlots = int.Parse(Console.ReadLine()); ;

        Console.WriteLine("Enter the number of truck slots:");
        int truckSlots = int.Parse(Console.ReadLine()); 

        ParkingSlot parkingSlot = new ParkingSlot(bikeSlots, carSlots, truckSlots);
        
        DisplayParkingSlots(parkingSlot);
        do
        {
            Console.WriteLine("\n\nEnter 1 to park vehicle \nEnter 2 to unpark vehicle \nEnter 3 to exit: ");
            exitCode = int.Parse(Console.ReadLine());
            if (exitCode == 1)
            {
                ParkVehicle(vehicles, parkingTickets, parkingSlot);
            } else if (exitCode == 2) 
            {
                UnparkVehicle(vehicles, parkingTickets, parkingSlot);
            } else
            {
                Console.WriteLine("\nInvalid input. Please try again.\n");
            }
        } while (exitCode != 3);
    }

    //see parkingslot current occupancy details
    private static void DisplayParkingSlots(ParkingSlot parkingSlot)
    {
        Console.WriteLine("\n\nCurrent parking slots:");
        Console.WriteLine($"Two wheeler slots: {parkingSlot.twoWheelerSlots}");
        Console.WriteLine($"Four wheeler slots: {parkingSlot.fourWheelerSlots}");
        Console.WriteLine($"Heavy vehicle slots: {parkingSlot.heavyVehicleSlots}");

    }

    //park vehicle and issue ticket
    private static void ParkVehicle(List<Vehicle> vehicles, List<ParkingTicket> parkingTickets, ParkingSlot parkingSlot)
    { 
        Console.WriteLine("\n\nEnter vehicle type (1 for two_wheeler, 2 for four_wheerler, 3 for heavy_vehicle):");
        int vehicleTypeInput = int.Parse(Console.ReadLine());
        do
        {
            if (vehicleTypeInput == 1)
            { 
                parkingSlot.twoWheelerSlots--;
            }
            else if (vehicleTypeInput == 2)
            {
                parkingSlot.fourWheelerSlots--;
            }
            else if (vehicleTypeInput == 3)
            {
                parkingSlot.heavyVehicleSlots--;
            }
            else
            {
                Console.WriteLine("\nInvalid vehicle type.\n");
            }

        } while (1 > vehicleTypeInput && vehicleTypeInput > 3);


        Console.WriteLine("\nEnter vehicle number plate:");
        string vehicleNumberPlate = Console.ReadLine();

        Vehicle vehicle = new Vehicle((VehicleType)vehicleTypeInput, vehicleNumberPlate);
        vehicles.Add(vehicle);
        IssueTicket(vehicle, parkingTickets);

    }
    private static void IssueTicket(Vehicle vehicle, List<ParkingTicket> parkingTickets)
    {
        ParkingTicket parkingTicket = new ParkingTicket(vehicle._vehicleNumberPlate, vehicle._vehicleType, DateTime.Now, null);
        parkingTickets.Add(parkingTicket);
        Console.WriteLine("\nTicket issued successfully.\n");
    }

    //unpark vehicle 
    private static void UnparkVehicle(List<Vehicle> vehicles, List<ParkingTicket> parkingTickets, ParkingSlot parkingSlot)
    {
        Console.WriteLine("\nEnter vehicle number plate:");
        string vehicleNumberPlate = Console.ReadLine();
        Vehicle vehicle = vehicles.Find(v => v._vehicleNumberPlate == vehicleNumberPlate);
        if (vehicle != null)
        {
            Console.WriteLine("\nEnter vehicle type (1 for two_wheeler, 2 for four_wheerler, 3 for heavy_vehicle):");
            int vehicleTypeInput = int.Parse(Console.ReadLine());
            do
            {
                if (vehicleTypeInput == 1)
                {
                    parkingSlot.twoWheelerSlots--;
                }
                else if (vehicleTypeInput == 2)
                {
                    parkingSlot.fourWheelerSlots--;
                }
                else if (vehicleTypeInput == 3)
                {
                    parkingSlot.heavyVehicleSlots--;
                }
                else
                {
                    Console.WriteLine("\nInvalid vehicle type.\n");
                }

            } while (1 > vehicleTypeInput && vehicleTypeInput > 3);
            ParkingTicket parkingTicket = parkingTickets.Find(t => t._vehicleNumberPlate == vehicleNumberPlate && t._outTime == DateTime.MinValue);
            if (parkingTicket != null)
            {
                parkingTicket._outTime = DateTime.Now;
                Console.WriteLine("\nVehicle unparked successfully.\n");
            }
            else if(parkingTickets.Find(t => t._vehicleNumberPlate == vehicleNumberPlate) != null)
            {
                Console.WriteLine("\nVehicle already unparked!!\n");
            }
            else
            {
                Console.WriteLine("\nNo ticket found for this vehicle.\n");
                Console.WriteLine($"parking ticket: ", parkingTickets);
            }
        }
        else
        {
            Console.WriteLine("\nNo vehicle found with this number.\n");
        }
    }
}