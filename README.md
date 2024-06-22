# Parking System
## Overview
The Parking System program manages a virtual parking lot where users can park vehicles, calculate parking fees, view parking status, and generate various reports based on plate numbers, vehicle types, and colors.

## Features
- **Create Parking Lot**: Initialize a parking lot with a specified number of slots.
- **Park Vehicle**: Park a vehicle by entering its type, registration number, and color.
- **Remove Vehicle**: Remove a parked vehicle from the parking lot and calculate parking fees.
- **View Parking Status**: Display the current status of occupied parking slots.
- **Find Your Car**: Locate a parked vehicle by entering its registration number.
- **Generate Reports**: Generate reports based on plate numbers, vehicle types, and colors.

## Validations
- Validates the format of the vehicle registration number (e.g., XX-XXXX-XXX).
- Checks for available parking slots before allowing vehicles to be parked.
- Ensures accurate input for generating reports.

## Prerequisites
- .NET Core SDK

## Preview
### Create Parking Lots

    Welcome to Parking System
    Insert Parking lot: 5
    Created a parking lot with 5 slots

### 1. Park Vehicle

    Vehicle parked!
    Plate Number = A-1111-AA
    Type         = Car
    Colour       = red
    Allocated slot number: 1
    Available slot: 4

### 2. Remove Vehicle

    Enter Vehicle Registration Number: A-1111-AA

    Parking Details:
    Plate Number   : A-1111-AA
    Vehicle Type   : Car
    Vehicle Colour : red
    CheckIn Time   : 22/06/2024 14:05:22
    CheckOut Time  : 22/06/2024 14:17:32
    Parked Duration: 0 hours
    Parking Fee    : 10,000 IDR

    Vehicle with registration number A-1111-AA has left the parking lot

### 3. Find Your Car

    Input your plate number : A-1111-AA

    You Park in slot 1

### 4. Display Status

    Slot    Regist. No.     Type            Colour  Check-In
    1       A-1111-AA       Car             Red     22/06/2024 14:18:39
    2       B-2222-BB       Motorcycle      White   22/06/2024 14:18:39
    3       C-3333-CC       Car             Green   22/06/2024 14:18:39
    4       DD-4444-DD      Motorcycle      Blue    22/06/2024 14:18:39
    5       EE-5555-EE      Car             WhItE   22/06/2024 14:18:39

### 5. Reports

    Enter the type of Report
    [1] Plate Number
    [2] Vehicle Type
    [3] Colour

    #### Plate Number Reports (e.g., Odd Plate)

    Enter type of Plate Number
    [1] Odd Plate Number
    [2] Even Plate Number
    Please select an option: 1

    Odd Plate Vehicles:
    A-1111-AA
    C-3333-CC
    EE-5555-EE

    #### Vehicle Type Reports (e.g., Car)

    Enter type of Vehicle
    [1] Car
    [2] Motorcycle
    Please select an option: 1

    Car count: 3

    #### Colour Reports (e.g., White)

    Vehicles with color 'White':
    Slot    Regist No.
    2       B-2222-BB
    5       EE-5555-EE

### 0. Exit

    Exiting program...
