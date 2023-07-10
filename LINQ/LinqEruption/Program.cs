List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
Console.WriteLine("-------------------------------");

Eruption FirstChile = eruptions.FirstOrDefault(e=>e.Location=="Chile");
Console.WriteLine(FirstChile.ToString());

Console.WriteLine("-------------------------------");

Eruption FirstHawaiian = eruptions.FirstOrDefault(e=>e.Location=="Hawaiian Is");
if(FirstHawaiian != null){
    Console.WriteLine(FirstHawaiian.ToString());
}else{
    Console.WriteLine("No Hawaiian Is eruption found.");
}

Console.WriteLine("-------------------------------");

Eruption FirstGreenland = eruptions.FirstOrDefault(e=>e.Location=="Greenland");
if(FirstGreenland != null){
    Console.WriteLine(FirstGreenland.ToString());
}else{
    Console.WriteLine("No Greenland eruption found.");
}

Console.WriteLine("-------------------------------");

Eruption FirstZealandAfter1900 = eruptions.FirstOrDefault(e=>e.Location=="New Zealand" && e.Year > 1900);
Console.WriteLine(FirstZealandAfter1900.ToString());

Console.WriteLine("-------------------------------");

List<Eruption> AllEruptions2000M = eruptions.Where(e=>e.ElevationInMeters > 2000).ToList();
PrintEach(AllEruptions2000M,"Eruptions above 2000M");

Console.WriteLine("-------------------------------");

List<Eruption> AllLEruptions = eruptions.Where(e=>e.Volcano.StartsWith("L")).ToList();
int AllLEruptionsCount = eruptions.Count(e=>e.Volcano.StartsWith("L"));
PrintEach(AllLEruptions,$"There are {AllLEruptionsCount} volcanos that start with L.");

Console.WriteLine("-------------------------------");

int HighestElevation = eruptions.Max(e=>e.ElevationInMeters);
Console.WriteLine($"The Highest Elevation is {HighestElevation}");

Console.WriteLine("-------------------------------");

Eruption HighestVolcano = eruptions.FirstOrDefault(e=>e.ElevationInMeters==HighestElevation);
Console.WriteLine(HighestVolcano.ToString());

Console.WriteLine("-------------------------------");

List<Eruption> AlphabeticVolcanos = eruptions.OrderBy(e=>e.Volcano).ToList();
PrintEach(AlphabeticVolcanos,"Volcanos Ordered Alphabetically");

Console.WriteLine("-------------------------------");

int TotalElevation = eruptions.Sum(e=>e.ElevationInMeters);
Console.WriteLine($"The Total Elevation is {TotalElevation} Meters");

Console.WriteLine("-------------------------------");

if(eruptions.Any(e=>e.Year == 2000)){
    Console.WriteLine("There is an eruption in 2000");
}else{
    Console.WriteLine("There is no eruption in 2000");
}

Console.WriteLine("-------------------------------");

List<Eruption> ThreeStrato = eruptions.Where(e=>e.Type=="Stratovolcano").Take(3).ToList();
PrintEach(ThreeStrato,"The First 3 Stratovolcanos");

Console.WriteLine("-------------------------------");

List<string> Before1000 = eruptions.Where(e=>e.Year < 1000).OrderBy(e=>e.Volcano).Select(e=>e.Volcano).ToList();
Console.WriteLine("Eruptions before 1000 CE:");
foreach(string v in Before1000){
    Console.WriteLine(v);
}