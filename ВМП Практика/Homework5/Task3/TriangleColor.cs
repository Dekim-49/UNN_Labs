using System;
public class TriangleColor : Triangle
{
    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public TriangleColor(string name, int a, int b, int c, string color):base(name, a, b, c)
    {
        Color = color;
    }

    public override double Area2 => base.Area2;

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("color = {0}", Color);
    }
}
 