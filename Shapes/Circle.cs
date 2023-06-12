using System.Runtime.CompilerServices;
using Shapes.Interfaces;

namespace Shapes;

internal class Circle : IShape
{
    const double PI = Math.PI;
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException();
        }
        _radius = radius;
    }

    public double GetSquare()
    {
        double square = PI * _radius * _radius;
        return square;
    }
}

