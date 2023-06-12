using Shapes.Interfaces;

namespace Shapes;

public class Triangle : IShape
{
    private double _a;
    private double _b;
    private double _c;

    public Triangle(double a, double b, double c)
    {
        if (IsCorrectTriangle(a, b, c))
        {
            _a = a;
            _b = b;
            _c = c;
        }
        else
        {
            throw new ArgumentException();
        }

    }

    public double GetSquare()
    {
        double p = GetPerimeter() / 2;
        double square = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        return square;
    }

    public bool IsRectangular()
    {
        bool b = _a * _a + _b * _b == _c * _c ||
                 _a * _a + _c * _c == _b * _b ||
                 _c * _c + _b * _b == _a * _a;
        return b;
    }

    private double GetPerimeter()
    {
        return _a + _b + _c;
    }

    private bool IsCorrectTriangle(double a, double b, double c)
    {
        bool result = a + b > c &&
                      a + c > b &&
                      c + b > a && 
                      a > 0 && 
                      b > 0 && 
                      c > 0;
        return result;
    }
}