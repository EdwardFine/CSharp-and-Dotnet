Attack Fireball = new Attack("Fireball",20);
Attack Punch = new Attack("Punch",10);
Attack Throw = new Attack("Throw",15);

Enemy Goblin = new Enemy("Goblin");
Goblin.AddAttack(Fireball);
Goblin.AddAttack(Punch);
Goblin.AddAttack(Throw);

Goblin.RandomAttack();
Goblin.RandomAttack();
Goblin.RandomAttack();
