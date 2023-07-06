public class MeleeFighter : Enemy{
    public MeleeFighter(string n) : base(n){
        AttackList = new List<Attack>(){new Attack("Punch",20),new Attack("Kick",15),new Attack("Tackle",25)};
    }
    public void Rage(Enemy Target){
        Attack ChosenAttack = RandomAttack();
        Target._Health -= (ChosenAttack.DamageAmount+10);
        Console.WriteLine($"{Name} attacks {Target.Name} in a fit of rage, dealing {ChosenAttack.DamageAmount+10} damage and reducing {Target.Name}'s health to {Target._Health}");
    }
}