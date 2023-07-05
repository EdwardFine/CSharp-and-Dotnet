static void coinFlip(){
    Random rand = new Random();
    if(rand.Next(2)==1){
        Console.WriteLine("Heads");
    }else{
        Console.WriteLine("Tails");
    }
}
coinFlip();
coinFlip();
coinFlip();
coinFlip();

static int rollDie(int sides){
    Random rand = new Random();
    return rand.Next(1,sides+1);
}
Console.WriteLine($"You rolled a {rollDie(6)}");
Console.WriteLine($"You rolled a {rollDie(6)}");
Console.WriteLine($"You rolled a {rollDie(20)}");
Console.WriteLine($"You rolled a {rollDie(20)}");


static List<int> statRoll(int numRolls=4,int dieSides = 6){
    List<int> stats = new List<int>();
    for(int i=0;i<numRolls;i++){
        stats.Add(rollDie(dieSides));
    }return stats;
}

List<int> stats = statRoll();
Console.WriteLine(stats.Max());

static void rollUntil(int goal=6){
    Random rand = new Random();
    int result = rand.Next(1,7);
    int count = 1;
    while(result!=goal){
        result = rand.Next(1,7);
        count++;
    }Console.WriteLine($"Rolled a {goal} after {count} tries!");
}

rollUntil(1);
rollUntil();