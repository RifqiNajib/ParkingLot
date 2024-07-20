namespace ParkingLot.Models
{
    public class Slot
    {
        public int Number { get; }
        public Vehicle? Vehicle { get; private set; }  

        public Slot(int number)
        {
            Number = number;
            Vehicle = null; 
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public void LeaveVehicle()
        {
            Vehicle = null;
        }

        public bool IsAvailable()
        {
            return Vehicle == null;
        }
    }
}
