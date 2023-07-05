public class Coffee : Drink{
    public string RoastValue;
    public string BeanType;
    public Coffee(string r,string b,string name, string color, double temp, bool iscarb, int cal) : base(name,color,temp,iscarb,cal){
        RoastValue = r;
        BeanType=b;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast Type: {RoastValue}");
        Console.WriteLine($"Bean Type: {BeanType}");
    }
}