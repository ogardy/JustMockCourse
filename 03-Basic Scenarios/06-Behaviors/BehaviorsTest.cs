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
  public async Task ShouldTestRecursiveLooseBehavior()
  {
    // Arrange 
    Player player = null;

    // Act 
    float actual = player.Position.GetDistanceTo(new Position(0, 10));

    // Assert
    player.Name.Should().Be(default);
    player.ScreamName().Should().Be(default);
    player.Position.Should().NotBeNull();
    actual.Should().Be(default);
  }

  [Fact]
  public async Task ShouldTestLooseBehavior()
  {
    // Arrange 
    Player player = null;

    // Assert
    player.Name.Should().Be(default);
    player.Position.Should().BeNull();
    player.ScreamName().Should().Be(default);
  }

  [Fact]
  public async Task ShouldTestCallOriginalBehavior()
  {
    // Arrange 
    Player player = null;

    // Act 
    float actual = player.Position.GetDistanceTo(new Position(0, 10));

    // Assert
    player.Name.Should().Be("William Adama");
    player.ScreamName().Should().Be("WILLIAM ADAMA");
    player.Position.Should().NotBeNull();
    actual.Should().Be(10);
  }

  [Fact]
  public async Task ShouldTestStrictBehavior()
  {
    // Arrange 
    Player player = null;

    // Act 
    Func<string> getName = () => player.Name;
    Func<string> screamName = () => player.ScreamName();
    Func<Position> getPosition = () => player.Position;

    // Assert
    // getName.Should().Throw<StrictMockException>();
    // screamName.Should().Throw<StrictMockException>();
    // getPosition.Should().Throw<StrictMockException>();
  }
}