Random rand = new Random();
//Prints a random integer between 0 and a C# constant.
Console.WriteLine(rand.Next());

//Prints a random integer between 0 and the given number (exclusive)
Console.WriteLine(rand.Next(10));

//Prints a random integer between the given minimum and maximum values (maximum exlcusive)
Console.WriteLine(rand.Next(2,8));

//Prints a random devimal value between 0.0 and 1.0
Console.WriteLine(rand.NextDouble());

//Arrays
//Arrays are immutable and mono-variable type. Int arrays can only store ints.

//Declare an empty int array with the given size, (5)
int[] myArray = new int[5];

//Declare a filled int array with the given values.
int[] myArray2 = new int[] {1,2,3,4,5};

//Can be declared without a size or value, but later has to use the new operator
int[] array3; 
array3 = new int[] {1,3,5,7,9}; 

//Still iterable
Console.WriteLine(myArray[0]);

myArray[2] = 9;

Console.WriteLine(myArray[2]);

// .length is CAPITALIZED
Console.WriteLine(myArray.Length);

//Iterate through a foreach loop
foreach(int num in myArray2){
    Console.WriteLine(num);
}

// Could use a normal for loop though
for(int i=0;i<myArray2.Length;i++){
    Console.WriteLine(myArray2[i]);
}

//Lists
//Lists are non-size restricted, but still mono-type

//Initialized with no variables
List<string> myList = new List<string>();

//Initialized with variables
List<string> filledList = new List<string>() {"Val1","Val2","Val3"};

//List methods
myList.Add("Value to add");

myList.Add("Test");

myList.Remove("Test");

Console.WriteLine(myList.Count);

myList.RemoveAt(0);

filledList.Insert(1,"Val1.5");

//Iterate through a foreach loop
foreach(string val in filledList){
    Console.WriteLine(val);
}

// Could use a normal for loop though
for(int i=0;i<filledList.Count;i++){
    Console.WriteLine(filledList[i]);
}

//Dictionaries

Dictionary<string,string> myDictionary = new Dictionary<string, string>();

myDictionary.Add("Name","Edward");

myDictionary.Add("Location","Oregon");

Console.WriteLine(myDictionary["Name"]);

//Iterate through a foreach loop
foreach(KeyValuePair<string,string> entry in myDictionary){
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}

//Functions
static int addNumbers(int a,int b){
    return a + b;
}

Console.WriteLine(addNumbers(5,3));

static void sayHello(){
    Console.WriteLine("Hello, World!");
}

sayHello();

//User Input

Console.WriteLine("Type something, then hit enter: ");
string inputLine = Console.ReadLine();
Console.WriteLine($"You wrote {inputLine}");

//Converting Values
string aNumber = "7";
int convertedInt = Convert.ToInt32(aNumber);
Console.WriteLine(14+convertedInt);

string aDecimal = "3.14";
double convertedDec = Convert.ToDouble(aDecimal);
Console.WriteLine(1.8 + convertedDec);

Console.WriteLine("Type a number, then hit enter: ");
string numberInput = Console.ReadLine();
if(Int32.TryParse(numberInput,out int j)){
    Console.WriteLine($"The integer was {j}");
    Console.WriteLine(10+j);
}

//Implicit Casting
int integerValue = 3;
double doubleValue = integerValue;

//Explicit Casting
double doubleValue2 = 3.14;
int integerValue2 = (int)doubleValue2;

//Unboxing
object boxedData = "This is clearly a String";
if(boxedData is int){
    Console.WriteLine("I guess we have an integer value in this box?");
}else if(boxedData is string){
    Console.WriteLine("It is totally a string in the box!");
}

//Safe Explicit Value
string explicitString = boxedData as string;