public class Soda : Drink{
    public bool IsDiet;
    public Soda(bool d,string name, string color, double temp, int cal) : base(name,color,temp,true,cal){
        IsDiet=d;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Is Diet? {IsDiet}");
    }
}