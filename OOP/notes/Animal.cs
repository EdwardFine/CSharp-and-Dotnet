class Animal{
    private string Name;

    public string Type {get;set;}

    public string _Name{
        get{return Name;}
        set{Name=value;}
    }

    public Animal(string n,string t){
        Name = n;
        Type = t;
    }
}