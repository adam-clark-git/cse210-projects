class Rectangle : Shape
{
    public double _length;
    public double _width;
    public Rectangle(double length, double width, string color) : base(color)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}
