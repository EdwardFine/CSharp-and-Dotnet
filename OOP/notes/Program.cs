//Animal is now abstract.
// Animal Giraffe = new Animal("Giraffe","Mammal","Herbavoire");

// Console.WriteLine(Giraffe.Type);

// Giraffe.Type = "Fish";

// Console.WriteLine(Giraffe.Type);

Cat Merida = new Cat("Merida","Orange Tabby");

Bird MyBird = new Bird(true,"Eagle","Carnivore",4);

Merida.ShowInfo();

List<Animal> AllAnimals = new List<Animal> {MyBird,Merida};

List<ILayEggs> EggLayers = new List<ILayEggs>(){MyBird};

foreach(ILayEggs layer in EggLayers){
    layer.LayEggs();
}

foreach(Animal a in AllAnimals){
    a.ShowInfo();
    if(a is Cat){
        Console.WriteLine("ACHOO!");
    }
}