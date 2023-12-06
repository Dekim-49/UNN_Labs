using System;

public abstract class Figure
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public abstract double Area2
    {
        get; 
       
    }
    public Figure(string name)
    {
        Name = name;
    }

    public abstract double Area();

    public virtual void Print()
    {
        Console.WriteLine("Name = {0}", Name);
    }
}

