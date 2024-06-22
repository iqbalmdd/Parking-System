using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_System.src
{
    public class ParkingLot {
        private int capacity;
        private Dictionary<int, Vehicle> slots;

        public ParkingLot(int size)
        {
            capacity = size;
            slots = new Dictionary<int, Vehicle>(size);
        }

        public int Park(Vehicle vehicle)
        {
            for (int i = 1; i <= capacity; i++)
            {
                if (!slots.ContainsKey(i))
                {
                    slots[i] = vehicle;
                    return i;
                }
            }
            return -1;
        }

        public int FindSlotByPlateNumber(string plateNumber)
        {
        foreach (var slot in slots)
        {
            if (slot.Value.PlateNumber.ToString() == plateNumber)
            {
                return slot.Key;
            }
        }
        return -1; // Not found
        }

        public bool Leave(string plateNumber)
        {
            int slotNumber = FindSlotByPlateNumber(plateNumber);
            if (slotNumber != -1)
            {
                slots.Remove(slotNumber);
                return true;
            }
            return false;
        }

        public void Status()
        {
            Console.WriteLine("Slot\tRegist. No.\tType\t\tColour\tCheck-In");
            foreach (var slot in slots)
            {
                var vehicle = slot.Value;
                Console.WriteLine($"{slot.Key}\t{vehicle.PlateNumber}\t{Enum.GetName(typeof(VehicleType), vehicle.Type),-15}\t{vehicle.Colour}\t{vehicle.CheckIn}");
            }
        }

        public int GetAvailableSlots()
        {
            return capacity - slots.Count;
        }

        public Dictionary<int, Vehicle> GetOccupiedSlots()
        {
            return slots;
        }
    }
}