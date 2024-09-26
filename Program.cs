// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Choose products. Close program by writing 'exit'");


string[] products = new string[0];
string validatedString = @"^[A-Z]+-(200|[2-4]\d{2}|500)$";

while (true)
{
    Console.Write("Choosen product: ");
    string input = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.White;

    if (input.ToLower().Trim() == "exit")
    {
        break;
    }
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Thou shant input an empty string unto thee! Try again.");
        Console.ForegroundColor = ConsoleColor.White;
        continue;

    }

    // Split the input on the dash '-'
    string[] parts = input.Split('-');
    if (parts.Length != 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You are missing or misplaced dash ('-'). Try again!");
        Console.ForegroundColor = ConsoleColor.White;
        continue;
    }

    string leftSide = parts[0];
    string rightSide = parts[1];

    if (string.IsNullOrWhiteSpace(leftSide) || !IsAllUppercaseLetters(leftSide))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The letters can only contain uppercase letters. Try again!");
        Console.ForegroundColor = ConsoleColor.White;
        continue;
    }

    
    if (!int.TryParse(rightSide, out int number) || number < 200 || number > 500)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The numbers can only contain an integer between 200 and 500. Try again!");
        Console.ForegroundColor = ConsoleColor.White;
        continue;
    }
    if (Regex.IsMatch(input, validatedString))
    {
        Array.Resize(ref products, products.Length + 1);
        products[products.Length - 1] = input;
    }
    
}

Console.WriteLine();
Console.WriteLine("You picked the following products in sorted order: ");
Console.WriteLine();
Array.Sort(products);
foreach(string product in products)
{
    Console.WriteLine("* " + product.ToUpper());
}
Console.ReadLine();


static bool IsAllUppercaseLetters(string input)
{
    foreach (char c in input)
    {
        if (!char.IsLetter(c) || !char.IsUpper(c))
        {
            return false;
        }
    }
    return true;
}



// Only exercises!
/* 
Random random = new Random();
int sum = 0;

for (int i = 0; i < 5; i++)
{
    int rand = random.Next(1,100);
    sum += rand;
}
Console.WriteLine("The total is = " + sum);
*/

/*
int generatedNr;

for (int i = 0; i < 5; i++) {
    
    
    int rand = random.Next(-10, 10);
    generatedNr = rand;
    int result = Math.Sign(generatedNr);
    if (result == 0)
{
    Console.WriteLine("It's just a 0 = " + generatedNr);
}
else if(result == 1)
{
    Console.WriteLine("Positive integer = " + generatedNr);
}
else
{
    Console.WriteLine("Negative integer = " + generatedNr);
}
}
*/

/*
    
    Console.WriteLine("How many numbers do you want to calculate? ");
    int amountOfNumbers;
while (true)
{
    Console.Write("Enter a positive number: ");
    if (int.TryParse(Console.ReadLine(), out amountOfNumbers) && amountOfNumbers > 0)
    {

        break;
    }
    else
    {
        Console.WriteLine("A zero or a negative is not a valid choice.");
    }
}

int[] numbersList = new int[amountOfNumbers];
    
    
    for(int i = 0;i < numbersList.Length; i++)
    {
    numbersList[i] = random.Next(1, 100);
    }
    
    int max = numbersList[0];
    int min = numbersList[0];
    int summary = 0;

for (int i = 0; i < numbersList.Length; i++)
{
    summary += numbersList[i];

    
    if (numbersList[i] < min)
    {
        min = numbersList[i];
    }

   
    if (numbersList[i] > max)
    {
        max = numbersList[i];
    }
}
double avg = (double)summary / amountOfNumbers;
Console.Write("Numbers generated = ");
foreach(int value in numbersList)
{
    Console.Write(value + " ");
}
Console.WriteLine("Biggest number = " + max);
Console.WriteLine("Smallest number = " + min);
Console.WriteLine("Total average of every integer = " + avg);
*/