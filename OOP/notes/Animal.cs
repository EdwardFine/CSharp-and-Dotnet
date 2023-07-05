public class Animal{
    private string Name;
    public string Diet;
    public string Type {get;set;}

    public string _Name{
        get{return Name;}
        set{Name=value;}
    }

    public Animal(string n,string t,string d){
        Name = n;
        Type = t;
        Diet = d;
    }

    public virtual void ShowInfo(){
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Diet: {Diet}");
    }
}