public class Bird : Animal, ILayEggs{
    public bool CanFly;
    public int EggsPerBatch{get;set;}
    public Bird(bool canfly, string type, string diet,int epb) : base("Bird",type,diet){
        CanFly = canfly;
        EggsPerBatch = epb;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Can Fly? {CanFly}");
    }
    public void LayEggs(){
        Console.WriteLine($"{_Name} laid {EggsPerBatch} egg(s)");
    }
}