namespace FunIdGenerator;

public sealed class GuIdGenerator(GuIdBuilder builder, Guid firstIdentifier)
    : IdGenerator<Guid>(builder, firstIdentifier)
{
    public static GuIdGenerator Build() => new(Guid.NewGuid, Guid.Empty);

    public override void Dispose() { }

    public override ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public override bool MoveNext()
    {
        latestIdentifier = builder();
        return true;
    }
}

public delegate Guid GuIdBuilder();
