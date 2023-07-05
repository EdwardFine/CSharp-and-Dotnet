//Arrays

int[] firstArray = new int[] {0,1,2,3,4,5,6,7,8,9};
string[] secondArray = new string[] {"Tim","Martin","Nikki","Sara"};
bool[] thirdArray = new bool[10];

for(int i=0;i<thirdArray.Length;i++){
    if(i%2==0){
        thirdArray[i]=true;
    }else{
        thirdArray[i]=false;
    }
}

//Lists

List<string> firstList = new List<string>() {"Vanilla","Chocolate","Strawberry","Mint Chocolate Chip","Cookie Dough"};

Console.WriteLine(firstList.Count);

Console.WriteLine(firstList[2]);

firstList.RemoveAt(2);

Console.WriteLine(firstList.Count);

Console.WriteLine(firstList[2]);

//Dictionary

Dictionary<string,string> firstDictionary = new Dictionary<string, string>();

Random rand = new Random();

foreach(string name in secondArray){
    firstDictionary.Add(name, firstList[rand.Next(0,4)]);
}
foreach(KeyValuePair<string,string> entry in firstDictionary){
    Console.WriteLine($"{entry.Key} likes {entry.Value} ice cream.");
}