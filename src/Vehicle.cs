using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_System.src
{
    public class Vehicle
    {
        public PlateNumber PlateNumber { get;set;} 
        public VehicleType Type { get;set;} 
        public string Colour { get;set;}
        public DateTime CheckIn { get;set;}
        public DateTime? CheckOut { get;set;}

        public Vehicle (PlateNumber plateNumber, VehicleType type, string colour){
            PlateNumber = plateNumber;
            Type = type;
            Colour = colour;
            CheckIn = DateTime.Now;
        }

    }
}