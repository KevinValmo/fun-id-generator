namespace FunIdGenerator.Tests;

[TestFixture]
public class GuIdGeneratorTests
{
    private GuIdGenerator _generator;

    [SetUp]
    public void SetUp()
    {
        _generator = GuIdGenerator.Build();
    }

    [Test]
    public void MoveNext_ShouldGenerateNewGuid()
    {
        // Arrange
        Guid initialIdentifier = _generator.Current;

        // Act
        _generator.MoveNext();

        // Assert
        Assert.That(_generator.Current, Is.Not.EqualTo(initialIdentifier));
    }

    [Test]
    public void UseGuIdGenereator_ShouldReturnGuIdGeneratorWithInitialIdentifierEmpty()
    {
        // Arrange
        Guid expectedInitialIdentifier = Guid.Empty;

        // Act
        GuIdGenerator generator = GuIdGenerator.Build();

        // Assert
        Assert.That(generator.Current, Is.EqualTo(expectedInitialIdentifier));
    }

    [TearDown]
    public void TearDown()
    {
        _generator.Dispose();
    }
}
