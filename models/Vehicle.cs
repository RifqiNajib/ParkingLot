namespace ParkingLot.Models
{
    public class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public string Type { get; }

        public Vehicle(string registrationNumber, string color, string type)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Type = type;
        }
    }
}
