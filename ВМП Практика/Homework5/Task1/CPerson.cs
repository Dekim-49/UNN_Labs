using System;

public class CPerson : ICloneable
{
	public string name;
	private int age;
	public int Age
	{
		get { return age; }
		set { if (value < 0) value = 0; age = value; }
	}

	public CPerson()
    {

    }
	public CPerson(string name, int age)
	{
		//Имя, возраст.
		// Студент: имя, возраст, препода, курс
		// Препод: имя. возраст, список студентов
		this.name = name;
		Age = age;
        
	}

	public virtual void Print()
    {
		Console.WriteLine("Name - {0}", name);
		Console.WriteLine("Age - {0}", age);
	}

    public override string ToString()
    {
		string Striiing;
		Striiing = "Name:" + name + " Age:" + (age.ToString());
		return Striiing;

	}

	public override bool Equals(Object obj)
	{
		if (obj == null || !(obj is CPerson))
			return false;
		else
			return ((name == ((CPerson)obj).name) && (age == ((CPerson)obj).age));
	}

    public override int GetHashCode()
    {
		int i = name.Length;     
		return (i*1000) + age;
    }

	public static CPerson RandomPerson(Object[] obj)
    {
		Random random = new Random();
		System.Threading.Thread.Sleep(500);
		int i = random.Next(obj.Length-1);
		return (CPerson)obj[i];
    }

	public virtual object Clone() => new CPerson(name, age);

}
