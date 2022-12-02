using LambdaUebung;
using System.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Beispiel 1: Converter");
        decimal[] converted = LambdaTest.Converter(new decimal[] { -10, 0, 10, 20, 30 }, x => x + 273.15M);
        LambdaTest.ForEach(converted, x => Console.WriteLine(x));

        Console.WriteLine("Beispiel 2: Filter");
        decimal[] freezed = LambdaTest.Filter(converted, x => x < 273.15M);
        LambdaTest.ForEach(freezed, x => Console.WriteLine(x));

        Console.WriteLine("Beispiel 3: Division");
        decimal result = LambdaTest.ArithmeticOperation(2, 0, (x, y) => { if (y == 0) { return 0; } return x / y; });
        Console.WriteLine(result);
        result = LambdaTest.ArithmeticOperation(2, 0, (x,y)=> x / y, x => Console.Error.WriteLine(x));
        Console.WriteLine(result);

        Console.WriteLine("Beispiel 4: Callback Funktion");
        LambdaTest.RunCommand(() => { Console.WriteLine("Hello World.");Console.WriteLine("Hello World again."); });

        Console.ReadLine();
    }

}