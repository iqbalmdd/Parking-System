using Parking_System.src;

public class ParkingService
{
    // Plate Number Service
    public PlateNumber newPlateNumber (string custPlate){
        var part = custPlate.Split("-");
        if (part.Length != 3)
        {
            throw new ArgumentException("Format Invalid! Plate Number Should be 'X-XXXX-XXX' ");
        }
        int.TryParse(part[1], out int numberPlate );
        return new PlateNumber(part[0],numberPlate,part[2]);
    }

    // Parking Lot Service
    private ParkingLot parkingLot;

    public void CreateParkingLot(int size){
        if (size <= 0)
        {
            Console.WriteLine("Lots can't Less than or Equal to 0");
        } else
        {
            parkingLot = new ParkingLot(size);
            Console.WriteLine($"Created a parking lot with {size} slots");
        }
    }

    public void newParking(){
        if (parkingLot.GetAvailableSlots() == 0)
        {
            Console.WriteLine("\n==Sorry parking lot is full==");
        } else
        {
            Console.WriteLine("\nEnter the type of Vehicle");
            Console.WriteLine("[1] Car");
            Console.WriteLine("[2] Motorcycle");
            Console.Write("Please select an option (1-2): ");

            // Input Vehicle Type
            var selectedType = Console.ReadLine();
            VehicleType type;
            if (selectedType == "1") {
                type = VehicleType.Car ;
            } else if (selectedType == "2")
            {
                type = VehicleType.Motorcycle;
            } else
            {
                Console.Write("Invalid Input\n");
                return;
            }

            // Input plateNumber
            Console.WriteLine("\nEnter Vehicle Registration Number");
            Console.WriteLine("e.g., `XX-XXXX-XXX`");
            Console.Write("Input your plate number : ");
            var clientPlate = Console.ReadLine();

            PlateNumber plateNumber = newPlateNumber(clientPlate);
            
            // Input Vehicle Colour
            Console.Write("\nEnter Vehicle Colour: ");
            var colour = Console.ReadLine();

            // Create Vehicle Object
            Vehicle vehicle = new Vehicle(plateNumber,type,colour);
            ParkVehicle(vehicle);
        }
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        int slot = parkingLot.Park(vehicle);
        
        if (slot == -1)
        {
            Console.WriteLine("Sorry parking lot is full");
        }
        else
        {
            Console.WriteLine($"\nVehicle parked!");
            Console.WriteLine($"Plate Number = {vehicle.PlateNumber}");
            Console.WriteLine($"Type         = {Enum.GetName(typeof(VehicleType), vehicle.Type)}");
            Console.WriteLine($"Colour       = {vehicle.Colour.ToLower()}");
            Console.WriteLine($"Allocated slot number: {slot}");
            Console.WriteLine($"Available slot: {parkingLot.GetAvailableSlots()}");
        }
    }


    public void RemoveVehicle() {
        Console.Write("\nEnter Vehicle Registration Number: ");
        var plateToLeave = Console.ReadLine();
        
        Vehicle vehicle = parkingLot.GetOccupiedSlots()
                                    .FirstOrDefault(v => v.Value.PlateNumber.ToString() == plateToLeave)
                                    .Value;

        if (vehicle != null) {
            vehicle.CheckOut = DateTime.Now;

            if (vehicle.CheckOut.HasValue)
            {
                TimeSpan parkedDuration = vehicle.CheckOut.Value - vehicle.CheckIn;
                double hoursParked = parkedDuration.TotalHours;

                double parkingFee = CalculateParkingFee(vehicle.Type, hoursParked);

                Console.WriteLine($"\nParking Details:");
                Console.WriteLine($"Plate Number   : {vehicle.PlateNumber}");
                Console.WriteLine($"Vehicle Type   : {Enum.GetName(typeof(VehicleType), vehicle.Type)}");
                Console.WriteLine($"Vehicle Colour : {vehicle.Colour.ToLower()}");
                Console.WriteLine($"CheckIn Time   : {vehicle.CheckIn}");
                Console.WriteLine($"CheckOut Time  : {vehicle.CheckOut}");
                Console.WriteLine($"Parked Duration: {Math.Floor(hoursParked)} hours");
                Console.WriteLine($"Parking Fee    : {parkingFee} IDR");
            }

            if (parkingLot.Leave(plateToLeave)) {
                Console.WriteLine($"\nVehicle with registration number {plateToLeave} has left the parking lot");
            } else {
                Console.WriteLine($"\nError: Vehicle with registration number {plateToLeave} could not be removed");
            }
        } else {
            Console.WriteLine($"\nVehicle with registration number {plateToLeave} not found");
        }
    }

public double CalculateParkingFee(VehicleType vehicleType, double hoursParked)
{
    double baseRate = (vehicleType == VehicleType.Motorcycle) ? 5000 : 10000;
    double additionalRate = (vehicleType == VehicleType.Motorcycle) ? 3000 : 5000;

    if (hoursParked <= 1)
    {
        return baseRate;
    }
    else
    {
        return baseRate + (Math.Ceiling(hoursParked - 1) * additionalRate);
    }
}

    public void DisplayStatus()
    {
        parkingLot.Status();
    }

    public void FindYourCar(){
        Console.Write("Input your plate number : ");
        var clientPlate = Console.ReadLine();

        int yourslot = parkingLot.FindSlotByPlateNumber(clientPlate);
        if (yourslot != -1)
        {
            Console.WriteLine($"You Park in slot {yourslot}");
        } else {
            Console.Write("\nNot found, Please Input the Correct Plate Number");
        }
        
    }

    public void Report(){
        Console.WriteLine("\nEnter the type of Report");
        Console.WriteLine("[1] Plate Number");
        Console.WriteLine("[2] Vehicle Type");
        Console.WriteLine("[3] Colour");
        Console.Write("Please select an option: ");
        var selectedReport = Console.ReadLine();
        switch (selectedReport) {
            case "1":
                Console.WriteLine("\nEnter type of Plate Number");
                Console.WriteLine("[1] Odd Plate Number");
                Console.WriteLine("[2] Even Plate Number");
                Console.Write("Please select an option: ");
                var plateType = Console.ReadLine();
                switch (plateType) {
                    case "1":
                        ReportOddEvenPlateNumbers(true);
                        break;
                    case "2":
                        ReportOddEvenPlateNumbers(false);
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                break;
            case "2":
                Console.WriteLine("\nEnter type of Vehicle");
                Console.WriteLine("[1] Car");
                Console.WriteLine("[2] Motorcycle");
                Console.Write("Please select an option: ");
                var VType = Console.ReadLine();
                switch (VType) {
                    case "1":
                        ReportVehicleTypes(VehicleType.Car);
                        break;
                    case "2":
                        ReportVehicleTypes(VehicleType.Motorcycle);
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                break;
            case "3":
                Console.Write("\nEnter Vehicle Colour : ");
                var VehicleColour = Console.ReadLine();
                ReportVehicleColors(VehicleColour);
                break;
            default:
                Console.WriteLine("Invalid option!");
                break;
        }
    }

    public void ReportVehicleColors(string vehicleColour)
    {
        var occupiedSlots = parkingLot.GetOccupiedSlots();

        var vehiclesOfColor = occupiedSlots.Values.Where(v => v.Colour.Equals(vehicleColour, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine($"\nVehicles with color '{vehicleColour}':");
        Console.WriteLine("Slot\tRegist No.");
        foreach (var vehicle in vehiclesOfColor)
        {
            int slot = parkingLot.FindSlotByPlateNumber(vehicle.PlateNumber.ToString());
            Console.WriteLine($"{slot}\t{vehicle.PlateNumber}");
        }
    }

    public void ReportOddEvenPlateNumbers(bool isOddReport)
    {
        var filteredVehicles = isOddReport ?
            parkingLot.GetOccupiedSlots().Values.Where(v => int.Parse(v.PlateNumber.ToString().Split('-')[1]) % 2 != 0).ToList() :
            parkingLot.GetOccupiedSlots().Values.Where(v => int.Parse(v.PlateNumber.ToString().Split('-')[1]) % 2 == 0).ToList();

        Console.WriteLine(isOddReport ? "Odd Plate Vehicles:" : "Even Plate Vehicles:");
        foreach (var vehicle in filteredVehicles)
        {
            Console.WriteLine(vehicle.PlateNumber);
        }
    }
    public void ReportVehicleTypes(VehicleType type)
    {
        var count = parkingLot.GetOccupiedSlots().Values.Count(v => v.Type == type);
        Console.WriteLine($"{type} count: {count}");
    }
}