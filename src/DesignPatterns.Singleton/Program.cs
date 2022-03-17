using DesignPatterns.Singleton.Better;
using DesignPatterns.Singleton.Classic;

Console.WriteLine("The classic singleton implementation");
new ExampleClassic().Run1();
Console.WriteLine();
new ExampleClassic().Run2();

Console.WriteLine();
Console.WriteLine("The improved singleton implementation");
new ExampleBetter().Run1();
Console.WriteLine();
new ExampleBetter().Run2();
