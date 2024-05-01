# Fun Id Generator

It has been a fun evening.
Feel free to add other `IdGenerator`s.

## Usage

```csharp
using FunIdGenerator;

// build IntIdGenerator
IntIdGenerator generator = IntIdGenerator.Build();

Console.Write("Current identifier: ");

// print the current identifier
Console.WriteLine(generator.Current); // -1
Console.WriteLine();

// move to the next identifier
generator.MoveNext();
Console.Write("Current identifier after moving to the next: ");
Console.WriteLine(generator.Current); // 0
Console.WriteLine();

// reset the generator to the initial identifier
generator.Reset();

// using LINQ to generate the first 10 identifiers
Console.Write("First 10 identifiers: ");
Console.WriteLine(string.Join(", ", generator.Take(5))); // 0, 1, 2, 3, 4
Console.WriteLine();

// reset the generator to the initial identifier
generator.Reset();

// using async foreach to generate identifiers
Console.WriteLine(
    """
    First 10 identifiers using async foreach:
    (escape key to exit, any key to continue the generation)
    """
);
await foreach (int identifier in generator)
{
    switch (Console.ReadKey().Key)
    {
        // escape the loop
        case ConsoleKey.Escape:
            return;
    }
    Console.WriteLine(identifier); // 0, 1, 2, ...
}
Console.WriteLine();

// dispose the generator
generator.Dispose();
```
