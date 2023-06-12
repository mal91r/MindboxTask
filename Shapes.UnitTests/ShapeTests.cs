using Shapes.Interfaces;

namespace Shapes.UnitTests;

public class ShapeTests
{
    [Fact]
    public void Shape_GetSquareOfRandomShape_CorrectSquare()
    {
        // Arrange 

        var random = new Random();

        var shapeType = random.Next(1, 3);

        IShape shape;

        switch (shapeType)
        {
            case 1:
                shape = new Circle(random.Next(0, 100));
                break;
            default:
                var side = random.Next(1, 100);
                shape = new Triangle(side, side, side);
                break;
        }

        // Act 

        var square = shape.GetSquare();

        // Assert

        Assert.True(square >= 0);
    }
}