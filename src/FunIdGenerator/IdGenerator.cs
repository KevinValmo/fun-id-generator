using System.Collections;

namespace FunIdGenerator;

public abstract class IdGenerator<TIdentifier>(Delegate builder, TIdentifier firstIdentifier)
    : IIdGenerator<TIdentifier>
    where TIdentifier : notnull
{
    protected readonly Delegate builder = builder;
    protected readonly TIdentifier firstIdentifier = firstIdentifier;
    protected TIdentifier latestIdentifier = firstIdentifier;

    public TIdentifier Current => latestIdentifier;

    object IEnumerator.Current => Current;

    public abstract void Dispose();

    public abstract ValueTask DisposeAsync();

    public IAsyncEnumerator<TIdentifier> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        return this;
    }

    public IEnumerator<TIdentifier> GetEnumerator() => this;

    public abstract bool MoveNext();

    public ValueTask<bool> MoveNextAsync() => ValueTask.FromResult(MoveNext());

    public void Reset() => latestIdentifier = firstIdentifier;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public interface IIdGenerator<TIdentifier>
    : IEnumerable<TIdentifier>,
        IEnumerator<TIdentifier>,
        IAsyncEnumerable<TIdentifier>,
        IAsyncEnumerator<TIdentifier>
    where TIdentifier : notnull;
