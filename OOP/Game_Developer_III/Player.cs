public class Player : Enemy{
    public Player(string name): base(name){
        AttackList = new List<Attack>(){new Attack("Punch",20),new Attack("Fireball",25),new Attack("Throw Knife",15), new Attack("Ultimate",30)};
    }
}