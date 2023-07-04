Random rand = new Random();
//Prints a random integer between 0 and a C# constant.
Console.WriteLine(rand.Next());

//Prints a random integer between 0 and the given number (exclusive)
Console.WriteLine(rand.Next(10));

//Prints a random integer between the given minimum and maximum values (maximum exlcusive)
Console.WriteLine(rand.Next(2,8));

//Prints a random devimal value between 0.0 and 1.0
Console.WriteLine(rand.NextDouble());