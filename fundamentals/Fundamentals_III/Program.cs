static void printList(List<string> myList){
    foreach(string entry in myList){
        Console.WriteLine(entry);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
printList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach(int num in IntList){
        sum += num;
    }Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
SumOfNumbers(TestIntList);

static int findMax(List<int> intList){
    int max = intList[0];
    foreach(int number in intList){
        if(number > max){
            max=number;
        }
    }return max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
Console.WriteLine(findMax(TestIntList2));

static List<int> squareValues(List<int> intList){
    List<int> squared = new List<int>();
    foreach(int num in intList){
        squared.Add(num*num);
    }return squared;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
List<int> squared = squareValues(TestIntList3);
foreach(int num in squared){
    Console.WriteLine(num);
}

static int[] nonNegatives(int[] intArray){
    int[] positives = new int[intArray.Length];
    for(int i =0;i<intArray.Length;i++){
        if(intArray[i]<0){
            positives[i]=0;
        }else{
            positives[i]=intArray[i];
        }
    }return positives;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
int[] noNegatives = nonNegatives(TestIntArray);
foreach(int num in noNegatives){
    Console.WriteLine(num);
}

static void printDictionary(Dictionary<string,string> myDictionary){
    foreach(KeyValuePair<string,string> entry in myDictionary){
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
printDictionary(TestDict);

static bool findKey(Dictionary<string,string> myDictionary, string searchTerm){
    foreach(KeyValuePair<string,string> entry in myDictionary){
        if(entry.Key == searchTerm){
            return true;
        }
    }return false;
}
Console.WriteLine(findKey(TestDict,"Powers"));
Console.WriteLine(findKey(TestDict,"Team"));

static Dictionary<string,int> generateDictionary(List<string> names, List<int> numbers){
    Dictionary<string,int> newdict = new Dictionary<string, int>();
    for(int i=0;i<names.Count;i++){
        newdict.Add(names[i],numbers[i]);
    }return newdict;
}
List<string> names = new List<string>() {"Julie","Harold","James","Monica"};
List<int> numbers = new List<int>() {6,12,7,10};
Dictionary<string,int> combined = generateDictionary(names,numbers);
foreach(KeyValuePair<string,int> entry in combined){
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}