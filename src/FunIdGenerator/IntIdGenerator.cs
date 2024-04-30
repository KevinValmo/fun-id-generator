namespace FunIdGenerator;

public sealed class IntIdGenerator(IntIdBuilder builder, int firstIdentifier)
    : IdGenerator<int>((ref int identifier) => builder(ref identifier), firstIdentifier)
{
    public override void Dispose() { }

    public override ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public override bool MoveNext()
    {
        builder(ref latestIdentifier);
        return true;
    }
}

public delegate int IntIdBuilder(ref int identifier);

public static class IntIdGeneratorExtensions
{
    public static IntIdGenerator Build() => new((ref int identifier) => identifier++, -1);
}
