namespace Shapes.UnitTests;

public class CircleTests
{
    [Fact]
    public void Circle_CreateCircleWithIncorrectRadius_ArgumentException()
    {
        // Arrange, Act, Assert

        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(2, 4 * Math.PI)]
    [InlineData(2.5, 6.25 * Math.PI)]
    public void Circle_GetSquare_ReturnsSquare(double r, double result)
    {
        // Arrange

        var circle = new Circle(r);

        // Act

        var square = circle.GetSquare();

        // Assert

        Assert.Equal(result, square);
    }
}