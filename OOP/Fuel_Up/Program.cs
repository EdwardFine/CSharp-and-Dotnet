Car Camry = new Car("Toyota","Camry","Gasoline","Red");
Car Civic = new Car("Honda","Civic","Gasoline", "Gray");
Car Pickup = new Car("Ford","Pickup Truck","Diesel","White",5,false);
Car Motorcycle = new Car("Harley","Chopper","Gasoline","Blue",2,true);

Horse Hugabear = new Horse("Stallion",15,"Hay","Golden");

Bicycle MyBike = new Bicycle(5,true,"Red");

//Can't make a Vehicle class because it it abstract.
//Vehicle TestVehicle = new Vehicle();

List<Vehicle> AllVehicles = new List<Vehicle> {Camry, Civic, Pickup,Motorcycle,Hugabear,MyBike};
List<Vehicle> AllFuel = new List<Vehicle>();


foreach(Vehicle v in AllVehicles){
    if(v is INeedFuel){
        AllFuel.Add(v);
    }
}
foreach(INeedFuel v in AllFuel){
    v.GiveFuel(10);
}
foreach(Vehicle v in AllFuel){
    v.ShowInfo();
}


