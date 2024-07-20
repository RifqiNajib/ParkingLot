using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingLotService
    {
        private readonly List<Slot> slots;

        public ParkingLotService(int capacity)
        {
            slots = new List<Slot>(capacity);
            for (int i = 1; i <= capacity; i++)
            {
                slots.Add(new Slot(i));
            }
        }

        public void Park(string registrationNumber, string color, string type)
        {
            var availableSlot = slots.FirstOrDefault(slot => slot.IsAvailable());
            if (availableSlot == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            var vehicle = new Vehicle(registrationNumber, color, type);
            availableSlot.ParkVehicle(vehicle);
            Console.WriteLine($"Allocated slot number: {availableSlot.Number}");
        }

        public void Leave(int slotNumber)
        {
            var slot = slots.FirstOrDefault(s => s.Number == slotNumber);
            if (slot != null && !slot.IsAvailable())
            {
                slot.LeaveVehicle();
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
            else
            {
                Console.WriteLine("Slot number not found or already free");
            }
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
            foreach (var slot in slots.Where(s => !s.IsAvailable()))
            {
                var vehicle = slot.Vehicle;
                 if (vehicle != null){
                Console.WriteLine($"{slot.Number}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Color}");
                  }
            }
        }

         public void PrintPlates(bool isOdd)
        {
            string plateType = isOdd ? "Odd" : "Even";
            Console.WriteLine($"{plateType} number plate registration numbers:");
            foreach (var slot in slots.Where(s => !s.IsAvailable() && IsPlateType(s.Vehicle?.RegistrationNumber, isOdd)))
            {
                var vehicle = slot.Vehicle;
                if (vehicle != null)
                {
                    Console.WriteLine($"{vehicle.RegistrationNumber}");
                }
            }
        }

        private bool IsPlateType(string? registrationNumber, bool isOdd)
        {
            if (string.IsNullOrEmpty(registrationNumber)) return false;
            char lastDigit = registrationNumber.Last();
            int digit = lastDigit - '0';
            return digit % 2 == (isOdd ? 1 : 0);
        }
    }
}
