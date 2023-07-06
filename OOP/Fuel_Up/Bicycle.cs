public class Bicycle : Vehicle{
    public int Gears;
    public bool IsOffRoad;
    public Bicycle(int gears, bool isoffroad, string color) : base("Bicycle",color,1,false){
        Gears = gears;
        IsOffRoad = isoffroad;
    }
}