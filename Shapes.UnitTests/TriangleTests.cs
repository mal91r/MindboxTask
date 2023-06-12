namespace Shapes.UnitTests;

public class TriangleTests
{
    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(2, 0, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 15, 5)]
    public void Triangle_CreateTriangleWithIncorrectSides_ArgumentException(double a, double b, double c)
    {
        // Arrange, Act, Assert

        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [InlineData(6, 8, 10)]
    public void Triangle_IsRectangular_True(double a, double b, double c)
    {
        // Arrange 

        var triangle = new Triangle(a, b, c);

        // Act 

        var isRectangular = triangle.IsRectangular();

        // Assert

        Assert.True(isRectangular);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 6)]
    [InlineData(3.5, 2.5, 2.5)]
    public void Triangle_IsRectangular_False(double a, double b, double c)
    {
        // Arrange 

        var triangle = new Triangle(a, b, c);

        // Act 

        var isRectangular = triangle.IsRectangular();

        // Assert

        Assert.False(isRectangular);
    }

    [Theory]
    [InlineData(3, 4 ,5, 6)]
    [InlineData(6, 8, 10, 24)]
    [InlineData(13, 14, 15, 84)]
    public void Triangle_GetSquare_ReturnsSquare(double a, double b, double c, double result)
    {
        // Arrange 

        var triangle = new Triangle(a, b, c);

        // Act 

        var square = triangle.GetSquare();

        // Assert

        Assert.Equal(square, result);
    }

}

