Vehicle Camry = new Vehicle("Toyota Camry","Red");
Vehicle Civic = new Vehicle("Honda Civic", "Gray");
Vehicle Pickup = new Vehicle("Pickup Truck","White",5,false);
Vehicle Motorcycle = new Vehicle("Motorcycle","Blue",2,true);

Vehicle[] AllVehicles = new Vehicle[] {Camry, Civic, Pickup,Motorcycle};

foreach(Vehicle car in AllVehicles){
    car.ShowInfo();
}
Camry.Travel(100);
Camry.ShowInfo();

//Wont Work due to private protection level.
//Camry.Miles = 350;
//Keeping distance traveled private can reduce the potential changing of a value that shouldn't be updated willy nilly.