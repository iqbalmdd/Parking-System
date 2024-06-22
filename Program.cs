using Parking_System.src;

class Program {
    static void Main(string[] args)
    {   
        var parkingService = new ParkingService();

        Console.WriteLine("Welcome to Parking System");
        Console.Write("Insert Parking lot: ");
        int Lots = int.Parse(Console.ReadLine());
        parkingService.CreateParkingLot(Lots);

        // Will be deleted
        Vehicle vehicle1 = new Vehicle(new PlateNumber("A",1111,"AA"),VehicleType.Car,"Red");
        Vehicle vehicle2 = new Vehicle(new PlateNumber("B",2222,"BB"),VehicleType.Motorcycle,"White");
        Vehicle vehicle3 = new Vehicle(new PlateNumber("C",3333,"CC"),VehicleType.Car,"Green");
        Vehicle vehicle4 = new Vehicle(new PlateNumber("D",4444,"DD"),VehicleType.Motorcycle,"Blue");
        Vehicle vehicle5 = new Vehicle(new PlateNumber("E",5555,"EE"),VehicleType.Car,"WhItE");
        parkingService.ParkVehicle(vehicle1);
        parkingService.ParkVehicle(vehicle2);
        parkingService.ParkVehicle(vehicle3);
        parkingService.ParkVehicle(vehicle4);
        parkingService.ParkVehicle(vehicle5);

        while(true){
            Console.WriteLine("\n=====Menu=====");
            Console.WriteLine("[1] Park Vehicle");
            Console.WriteLine("[2] Remove Vehicle");
            Console.WriteLine("[3] Display Status");
            Console.WriteLine("[4] Report");
            Console.WriteLine("[0] Exit");

            Console.Write("Please select number in option : ");
            var selectedNumber = Console.ReadLine();
            switch(selectedNumber){

                // New Parking
                case "1": 
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
                        break;
                    }

                    // Input plateNumber
                    Console.WriteLine("\nEnter Vehicle Registration Number");
                    Console.WriteLine("exp: `XX-XXXX-XXX`");
                    Console.Write("Input your plate number : ");
                    var clientPlate = Console.ReadLine();

                    PlateNumber plateNumber = parkingService.newPlateNumber(clientPlate);
                    
                    // Input Vehicle Colour
                    Console.Write("\nEnter Vehicle Colour: ");
                    var colour = Console.ReadLine();

                    // Create Vehicle Object
                    Vehicle vehicle = new Vehicle(plateNumber,type,colour);
                    parkingService.ParkVehicle(vehicle);
                    break;

                case "2":
                    // Input plateNumber
                    Console.Write("\nEnter Vehicle Registration Number: ");
                    var plateToLeave = Console.ReadLine();
                    parkingService.RemoveVehicle(plateToLeave);

                    break;
                case "3":
                    parkingService.DisplayStatus();
                    break;
                case "4":
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
                                    parkingService.ReportOddEvenPlateNumbers(true);
                                    break;
                                case "2":
                                    parkingService.ReportOddEvenPlateNumbers(false);
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
                                    parkingService.ReportVehicleTypes(VehicleType.Car);
                                    break;
                                case "2":
                                    parkingService.ReportVehicleTypes(VehicleType.Motorcycle);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option!");
                                    break;
                            }
                            break;
                    case "3":
                            Console.Write("\nEnter Vehicle Colour : ");
                            var VehicleColour = Console.ReadLine();
                            parkingService.ReportVehicleColors(VehicleColour);
                            break;
                    default:
                            Console.WriteLine("Invalid option!");
                            break;
                }
                break;
                case "0":
                    // Exit the program
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
        
    }

}

