using FluentAssertions;
using System.Numerics;

namespace JustMockCourse.BasicScenarios.Behaviors;

public class Player
{
  public string Name { get; } = "William Adama";
  public Position Position { get; } = new Position(10, 10);

  public Player(string name, Position position)
  {
    Name = name;
    Position = position;
  }

  public string ScreamName() => Name.ToUpper();
}

public class Position
{
  public Vector2 Vector { get; }

  public Position(float x, float y)
  {
    Vector = new Vector2(x, y);
  }

  public float GetDistanceTo(Position other)
  {
    return Vector2.Distance(Vector, other.Vector);
  }
}

public class BehaviorsTest
{
  [Fact]
  public void ShouldTestRecursiveLooseBehavior()
  {
    // Arrange 
    Player player = null;

    // Act 
    float actual = player.Position.GetDistanceTo(new Position(0, 10));

    // Assert
    player.Name.Should().Be(default);
    player.ScreamName().Should().Be(default);
    player.Position.Should().NotBeNull();
    player.Position.Should().BeOfType<Position>();  
    actual.Should().Be(default);
  }

  [Fact]
  public void ShouldTestLooseBehavior()
  {
    // Arrange 
    Player player = null;

    // Assert
    player.Name.Should().Be(default);
    player.ScreamName().Should().Be(default);
    player.Position.Should().BeNull();
  }

  [Fact]
  public void ShouldTestCallOriginalBehavior()
  {
    // Arrange 
    Player player = null;

    // Act 
    float actual = player.Position.GetDistanceTo(new Position(0, 10));

    // Assert
    player.Name.Should().Be("William Adama");
    player.ScreamName().Should().Be("WILLIAM ADAMA");
    player.Position.Should().NotBeNull();
    player.Position.Should().BeOfType<Position>();
    actual.Should().Be(10);
  }

  [Fact]
  public void ShouldTestStrictBehavior()
  {
    // Arrange 
    Player player = null;

    string expected = "GAIUS BALTAR";

    // Act 
    Func<string> getName = () => player.Name;
    Func<Position> getPosition = () => player.Position;
    string actual = player.ScreamName();

    // Assert
    // getName.Should().Throw<StrictMockException>();
    // getPosition.Should().Throw<StrictMockException>();
    actual.Should().Be(expected);
  }
}