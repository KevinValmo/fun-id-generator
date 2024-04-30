namespace FunIdGenerator.Tests;

[TestFixture]
public class IntIdGeneratorTests
{
    private IntIdGenerator _generator;

    [SetUp]
    public void SetUp()
    {
        _generator = IntIdGeneratorExtensions.Build();
    }

    [Test]
    public void MoveNext_ShouldIncreaseIdentifier()
    {
        // Arrange
        int initialIdentifier = _generator.Current;

        // Act
        _generator.MoveNext();

        // Assert
        Assert.That(_generator.Current, Is.EqualTo(initialIdentifier + 1));
    }

    [Test]
    public void Build_ShouldReturnIntIdGeneratorWithInitialIdentifierMinusOne()
    {
        // Arrange
        int expectedInitialIdentifier = -1;

        // Act
        IntIdGenerator generator = IntIdGeneratorExtensions.Build();

        // Assert
        Assert.That(generator.Current, Is.EqualTo(expectedInitialIdentifier));
    }

    [TearDown]
    public void TearDown()
    {
        _generator.Dispose();
    }
}
