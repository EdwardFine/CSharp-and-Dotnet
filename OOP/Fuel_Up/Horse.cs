public class Horse : Vehicle,INeedFuel{
    public string Breed;
    public int Age;
    public string FuelType{get;set;}
    public int FuelTotal{get;set;}
    public Horse(string breed, int age,string fueltype,string color, int p=1): base("Horse",color,p,false){
        Breed = breed;
        Age = age;
        FuelType = fueltype;
        FuelTotal=10;
    }
    public void GiveFuel(int Amount){
        Console.WriteLine($"You gave your horse {Amount} bundles of {FuelType}!");
        FuelTotal += 
        Amount;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Total Fuel: {FuelTotal}");
        Console.WriteLine("");
    }
}