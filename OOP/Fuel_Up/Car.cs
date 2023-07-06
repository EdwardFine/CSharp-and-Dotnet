public class Car : Vehicle,INeedFuel{
    public string Make;
    public string FuelType{get;set;}
    public int FuelTotal{get;set;}
    public string Model;
    public Car(string make,string model,string fueltype, string color, int p=4,bool engine=true): base("Car",color,p,engine){
        Make = make;
        Model=model;
        FuelType = fueltype;
        FuelTotal = 10;
    }
    public void GiveFuel(int Amount){
        Console.WriteLine($"You got {Amount} gallons of {FuelType}!");
        FuelTotal += Amount;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Total Fuel: {FuelTotal}");
        Console.WriteLine("");
    }
}