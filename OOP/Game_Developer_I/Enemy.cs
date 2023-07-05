class Enemy{
    string Name;
    private int Health;
    public int _Health{
        get{return Health;}
    }
    public List<Attack> AttackList;

    public Enemy(string n){
        Name=n;
        Health=100;
        AttackList = new List<Attack>();
    }

    public void RandomAttack(){
        Random rand = new Random();
        Console.WriteLine($"The {Name} attacks with a {AttackList[rand.Next(AttackList.Count)].Name}");
    }

    public void AddAttack(Attack att){
        AttackList.Add(att);
    }
}