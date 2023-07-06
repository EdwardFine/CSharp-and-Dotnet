MeleeFighter Reinhardt = new MeleeFighter("Reinhardt");
RangedFighter Widowmaker = new RangedFighter("Widowmaker");
MagicCaster Zenyatta = new MagicCaster("Zenyatta");
Reinhardt.PerformAttack(Widowmaker,Reinhardt.AttackList[1]);
Reinhardt.Rage(Zenyatta);

Widowmaker.PerformAttack(Reinhardt,Widowmaker.AttackList[0]);
Widowmaker.Dash();
Widowmaker.PerformAttack(Reinhardt,Widowmaker.AttackList[0]);

Zenyatta.PerformAttack(Reinhardt,Zenyatta.AttackList[0]);
Zenyatta.Heal(Widowmaker);
Zenyatta.Heal(Zenyatta);