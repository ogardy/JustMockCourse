using FluentAssertions;

namespace JustMockCourse.BasicScenarios.PublicProperties;

public interface IEntity
{
  int Id { get; set; }
}

public class PropertiesTest
{
  [Fact]
  public void ShouldFakePropertyGet()
  {
    // Arrange 
    IEntity entity = null;

    // Act 
    int actual = entity.Id;

    // Assert 
    actual.Should().Be(25);
  }

  [Fact]
  public void ShouldAssertPropertySet()
  {
    // Arrange 
    IEntity entity = null;

    // Act 
    entity.Id = 1;

    // Assert 
    // Mock.AssertSet(() => entity.Id = 1);
  }

  [Fact]
  public void ShouldThrowExceptionOnTheThirdPropertySetCall()
  {
    // Arrange 
    IEntity entity = null;

    // Act 
    entity.Id = 4;
    entity.Id = 5;

    void act() => entity.Id = 15;

    // Assert 
    // act.Should().Throw<StrictMockException>();
  }
}