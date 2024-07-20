using System;
using ParkingLot.Services;

class Program
{
    static void Main(string[] args)
    {
        ParkingLotService? parkingLot = null; 

        while (true)
        {
            string? command = Console.ReadLine();  
            if (string.IsNullOrWhiteSpace(command))
            {
                continue;
            }
            
            string[] commandParts = command.Split(' ');

            switch (commandParts[0])
            {
                case "create_parking_lot":
                    if (commandParts.Length != 2 || !int.TryParse(commandParts[1], out int capacity))
                    {
                        Console.WriteLine("Invalid command");
                        break;
                    }
                    parkingLot = new ParkingLotService(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                    break;

                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }
                    if (commandParts.Length != 4)
                    {
                        Console.WriteLine("Invalid command");
                        break;
                    }
                    string registrationNumber = commandParts[1];
                    string color = commandParts[2];
                    string type = commandParts[3];
                    parkingLot.Park(registrationNumber, color, type);
                    break;

                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }
                    if (commandParts.Length != 2 || !int.TryParse(commandParts[1], out int slotNumber))
                    {
                        Console.WriteLine("Invalid command");
                        break;
                    }
                    parkingLot.Leave(slotNumber);
                    break;

                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }
                    parkingLot.Status();
                    break;

                case "registration_numbers_for_vehicles_with_odd_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }
                    parkingLot.PrintPlates(true);
                    break;

                case "registration_numbers_for_vehicles_with_even_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }
                    parkingLot.PrintPlates(false);
                    break;

                // --
                case "exit":
                    return;

                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }
        }
    }
}
