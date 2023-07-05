Animal Giraffe = new Animal("Giraffe","Mammal","Herbavoire");

Console.WriteLine(Giraffe.Type);

Giraffe.Type = "Fish";

Console.WriteLine(Giraffe.Type);

Cat Merida = new Cat("Merida","Orange Tabby");

Merida.ShowInfo();

List<Animal> AllAnimals = new List<Animal> {Giraffe,Merida};

foreach(Animal a in AllAnimals){
    a.ShowInfo();
    if(a is Cat){
        Console.WriteLine("ACHOO!");
    }
}