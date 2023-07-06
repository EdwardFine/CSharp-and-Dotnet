public class MagicCaster : Enemy{
    public MagicCaster(string name) : base(name){
        _Health = 80;
        AttackList = new List<Attack>(){new Attack("Fireball",25),new Attack("Lightning Bolt",20),new Attack("Staff Strike",10)};
    }
    public void Heal(Enemy Target){
        if(Target._Health + 40 > 100){
            Target._Health = 100;
        }else{
            Target._Health += 40;
        }
        Console.WriteLine($"{Name} healed {Target.Name} for 40 health. Bringing their health to {Target._Health}");
    }
}