using Parking_System.src;

class Program {
    static void Main(string[] args)
    {   
        var parkingService = new ParkingService();

        Console.WriteLine("Welcome to Parking System");
        Console.Write("Insert Parking lot: ");
        int Lots = int.Parse(Console.ReadLine());
        parkingService.CreateParkingLot(Lots);

        // Dummy Data (Lots has to = 5 to use this dummy)
        if (Lots == 5) {
            Vehicle vehicle1 = new Vehicle(new PlateNumber("A",1111,"AA"),VehicleType.Car,"Red");
            Vehicle vehicle2 = new Vehicle(new PlateNumber("B",2222,"BB"),VehicleType.Motorcycle,"White");
            Vehicle vehicle3 = new Vehicle(new PlateNumber("C",3333,"CC"),VehicleType.Car,"Green");
            Vehicle vehicle4 = new Vehicle(new PlateNumber("DD",4444,"DD"),VehicleType.Motorcycle,"Blue");
            Vehicle vehicle5 = new Vehicle(new PlateNumber("EE",5555,"EE"),VehicleType.Car,"WhItE");
            parkingService.ParkVehicle(vehicle1);
            parkingService.ParkVehicle(vehicle2);
            parkingService.ParkVehicle(vehicle3);
            parkingService.ParkVehicle(vehicle4);
            parkingService.ParkVehicle(vehicle5);
        }
        

        while(true){
            Console.WriteLine("\n=====Menu=====");
            Console.WriteLine("[1] Park Vehicle");
            Console.WriteLine("[2] Remove Vehicle");
            Console.WriteLine("[3] Find Your Vehicle");
            Console.WriteLine("[4] Display Status");
            Console.WriteLine("[5] Report");
            Console.WriteLine("[0] Exit");

            Console.Write("Please select number in option : ");
            var selectedNumber = Console.ReadLine();
            switch(selectedNumber){

                case "1": 
                    parkingService.newParking();
                    break;
                case "2":
                    parkingService.RemoveVehicle();
                    break;
                case "3":
                    parkingService.FindYourCar();
                    break;
                case "4":
                    parkingService.DisplayStatus();
                    break;
                case "5":
                    parkingService.Report();
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
        
    }

}

