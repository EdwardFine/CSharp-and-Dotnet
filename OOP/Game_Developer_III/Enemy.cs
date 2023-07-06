public class Enemy{
    public string Name{get;}
    private int Health;
    public int _Health{
        get{return Health;}
        set{Health=value;}
    }
    public List<Attack> AttackList;

    public Enemy(string n){
        Name=n;
        Health=100;
        AttackList = new List<Attack>();
    }

    public Attack RandomAttack(){
        Random rand = new Random();
        return AttackList[rand.Next(AttackList.Count)];
    }

    public void AddAttack(Attack att){
        AttackList.Add(att);
    }
    public virtual void ShowStats(){
        Console.WriteLine($"Health: {Health}");
    }
    public virtual void Dash(){

    }
    public virtual void Heal(Enemy target){

    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack){
        if(_Health >0){
            if(Target._Health > 0){
                Target._Health -= ChosenAttack.DamageAmount;
                Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target._Health}");
            }else{
                Console.WriteLine($"{Target.Name} already has 0 health and cannot be attacked.");
            }
        }else{
            Console.WriteLine($"{Name} cannot attack as their health is below 0.");
        }
    }
}