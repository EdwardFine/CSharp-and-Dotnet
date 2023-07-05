Drink Water = new Drink("Water","Clear",70.0,false,0);

Soda Pepsi = new Soda(false,"Pepsi","Brown",40.5,150);

Coffee Black = new Coffee("Black","Madigascar","Coffee","Black",176.7,false,100);

Wine Red = new Wine("Italy", 1978,"Red Wine","Red",50.0,false,120);

List<Drink> AllDrinks = new List<Drink>{Water,Pepsi,Black,Red};

foreach(Drink drink in AllDrinks){
    drink.ShowDrink();
    if(drink is Wine){
        Console.WriteLine("I'm Drunk");
    }
}