namespace FunIdGenerator;

public sealed class GuIdGenerator(GuIdBuilder builder, Guid firstIdentifier)
    : IdGenerator<Guid>(builder, firstIdentifier)
{
    public override void Dispose() { }

    public override ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public override bool MoveNext()
    {
        latestIdentifier = builder();
        return true;
    }
}

public delegate Guid GuIdBuilder();

public static class GuIdGeneratorExtensions
{
    public static GuIdGenerator UseGuIdGenereator() => new(Guid.NewGuid, Guid.Empty);
}
