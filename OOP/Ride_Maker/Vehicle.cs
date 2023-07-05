class Vehicle{
    string Name;
    int Passengers;
    string Color;
    bool Engine;
    private int Miles;

    public Vehicle(string n,string c,int p=4, bool e=true){
        Name = n;
        Passengers=p;
        Color=c;
        Engine=e;
        Miles=0;
    }

    public void ShowInfo(){
        Console.Write($"Name: {Name}\nColor: {Color}\n# of Passengers: {Passengers}\nHas engine? {Engine}\nMiles Driven: {Miles}\n\n");
    }

    public void Travel(int distance){
        Miles += distance;
        Console.WriteLine($"Your {Name} has driven {distance} miles. New total miles is {Miles} miles.");
    }
}