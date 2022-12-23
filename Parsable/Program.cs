



using Parsable;

int i = int.Parse("1234");
Console.WriteLine(i);

int j = 0;
if(int.TryParse("1234", out j))
{
    Console.Error.WriteLine("nope!"); 
}

int wordsCount = "Hello World! Lorem Ipsum whatever".CountWords();


Person p = "Martin, Schrutek,13.05.1977".Parse<Person>();
Console.WriteLine(p);
Console.Read();