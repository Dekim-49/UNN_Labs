using System;

public class Triangle : Figure
{
    private int a;
    private int b;
    private int c;


    public void SetABC(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void GetABC(out int a, out int b, out int c)
    {
        a = this.a;
        b = this.b;
        c = this.c;
    }

    public Triangle(string name, int a, int b, int c):base(name)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Area2
    { 
        get => Math.Sqrt(((a + b + c) / 2) * (((a + b + c) / 2) - a) * (((a + b + c) / 2) - b) * (((a + b + c) / 2) - c));
        
    }
       


    public override double Area()
    {
        return (double)Math.Sqrt(((a + b + c) / 2) * (((a + b + c) / 2) - a) * (((a + b + c) / 2) - b) * (((a + b + c) / 2) - c));

    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
        Console.WriteLine("c = {0}", c);
    }
}


