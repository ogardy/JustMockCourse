using FluentAssertions;

namespace JustMockCourse.BasicScenarios.Generics;

public class Calculator
{
  public T Add<T>(T first, T second)
  {
    throw new NotImplementedException();
  }
}

public class GenericsTest
{
  [Fact]
  public void ShouldDistinguishCallsDependingOnArgumentTypes()
  {
    // Arrange 
    Calculator calculator = new Calculator();

    int expectedWithInts = 5;
    string expectedWithStrings = "7";

    // Act 
    int actualWithInts = calculator.Add(2, 3);
    string actualWithStrings = calculator.Add("3", "4");

    // Assert 
    actualWithInts.Should().Be(expectedWithInts);
    actualWithStrings.Should().Be(expectedWithStrings);
  }
}