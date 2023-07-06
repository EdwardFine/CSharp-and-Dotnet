public class RangedFighter : Enemy{
    public int Distance;
    public RangedFighter(string n) : base(n){
        Distance = 5;
        AttackList = new List<Attack>(){new Attack("Shoot An Arrow",20),new Attack("Throw a Knife",15)};
    }
    public override void Dash(){
        Distance += 20;
        Console.WriteLine($"{Name} dashes away, bringing the total distance to {Distance}.");
    }
    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if(Distance >= 10){
        base.PerformAttack(Target,ChosenAttack);
        }else{
            Console.WriteLine($"{Name} cannot attack because they are too close!");
        }
    }
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"Distance: {Distance}");
    }
}