public class Wine : Drink {
    public string Region;
    public int Year;
    public Wine(string r, int y, string name, string color, double temp, bool iscarb, int cal) : base(name,color,temp,iscarb,cal){
        Region = r;
        Year=y;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {Year}");
    }
}