MeleeFighter Reinhardt = new MeleeFighter("Reinhardt");
RangedFighter Widowmaker = new RangedFighter("Widowmaker");
MagicCaster Zenyatta = new MagicCaster("Zenyatta");
List<Enemy> AllEnemies = new List<Enemy> {Reinhardt, Widowmaker, Zenyatta};
Random rand = new Random();
// Reinhardt.PerformAttack(Widowmaker,Reinhardt.AttackList[1]);
// Reinhardt.Rage(Zenyatta);

// Widowmaker.PerformAttack(Reinhardt,Widowmaker.AttackList[0]);
// Widowmaker.Dash();
// Widowmaker.PerformAttack(Reinhardt,Widowmaker.AttackList[0]);

// Zenyatta.PerformAttack(Reinhardt,Zenyatta.AttackList[0]);
// Zenyatta.Heal(Widowmaker);
// Zenyatta.Heal(Zenyatta);
Console.WriteLine("What is your name Weary traveler? ");
Player player = new Player(Console.ReadLine());
Enemy opponent = AllEnemies[rand.Next(0,AllEnemies.Count)];
while(player._Health > 0 && opponent._Health > 0){
    Console.WriteLine("Player Stats:");
    player.ShowStats();
    Console.WriteLine("");
    Console.WriteLine($"{opponent.Name}'s Stats:");
    opponent.ShowStats();
    Console.WriteLine("");
    Console.WriteLine("What move do you want to do? ");
    while(true){
        for(int i=0;i<player.AttackList.Count;i++){
            Console.WriteLine($"{i+1}. {player.AttackList[i].Name}");
        }string userChoice = Console.ReadLine();
        if(Int32.TryParse(userChoice,out int UserChoiceNum)){
            if(UserChoiceNum > 0 && UserChoiceNum < 5){
                player.PerformAttack(opponent,player.AttackList[UserChoiceNum-1]);
                break;
            }
        }Console.WriteLine("Please input a valid number.");
    }
    if(opponent._Health<=0){
        break;
    }else{
        if(opponent is MeleeFighter){
            opponent.PerformAttack(player,opponent.AttackList[rand.Next(0,opponent.AttackList.Count)]);
        }else if(opponent is RangedFighter){
            int OpponentChoice = rand.Next(0,opponent.AttackList.Count+1);
            if(OpponentChoice == opponent.AttackList.Count){
                opponent.Dash();
            }else{
                opponent.PerformAttack(player,opponent.AttackList[OpponentChoice]);
            }
        }else if(opponent is MagicCaster){
            int OpponentChoice = rand.Next(0,opponent.AttackList.Count+1);
            if(OpponentChoice == opponent.AttackList.Count){
                opponent.Heal(opponent);
            }else{
                opponent.PerformAttack(player,opponent.AttackList[OpponentChoice]);
            }
        }
    }
}
if(player._Health <=0){
    Console.WriteLine($"{opponent.Name} Wins");
}else{
    Console.WriteLine($"Congratulations, you win!");
}