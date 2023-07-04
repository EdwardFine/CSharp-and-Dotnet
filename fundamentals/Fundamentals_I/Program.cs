Random rand = new Random();
for(int i=1;i<=255;i++){
    Console.WriteLine(i);
}

int sum=0;
for(int i=0;i<5;i++){
    sum += rand.Next(10,21);
}
Console.WriteLine(sum);

for(int i=1;i<=100;i++){
    if(i % 3 == 0 && i % 5 == 0){
        Console.WriteLine("FizzBuzz");
    }else if(i % 3 == 0){
        Console.WriteLine("Fizz");
    }else if(i % 5 ==0){
        Console.WriteLine("Buzz");
    }
}

//While Loops
int j = 1;
while(j<=255){
    Console.WriteLine(j);
    j++;
}

sum=0;
j=0;
while(j<5){
    sum+=rand.Next(10,21);
    j++;
}Console.WriteLine(sum);

j=1;
while(j<=100){
    if(j % 3 == 0 && j % 5 == 0){
        Console.WriteLine("FizzBuzz");
    }else if(j % 3 == 0){
        Console.WriteLine("Fizz");
    }else if(j % 5 ==0){
        Console.WriteLine("Buzz");
    }j++;
}