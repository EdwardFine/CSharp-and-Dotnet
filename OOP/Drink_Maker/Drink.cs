public class Drink{
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;

    public Drink(string n, string col, double t, bool i, int cal){
        Name=n;
        Color=col;
        Temperature=t;
        IsCarbonated=i;
        Calories=cal;
    }

    public virtual void ShowDrink(){
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Temperature: {Temperature}");
        Console.WriteLine($"Is Carbonated? {IsCarbonated}");
        Console.WriteLine($"Calories: {Calories}");
    }
}