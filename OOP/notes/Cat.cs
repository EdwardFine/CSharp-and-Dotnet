public class Cat : Animal{
    public string FurType;
    public Cat(string name,string f) : base(name,"Mammal","Omnivorous"){
        FurType=f;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Fur Type: {FurType}");
    }
}