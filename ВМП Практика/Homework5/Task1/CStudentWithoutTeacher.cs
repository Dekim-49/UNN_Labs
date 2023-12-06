using System;

public class CStudentWithoutTeacher : CPerson
{
	private int course;
	public int Course
	{
		get { return course; }
		set { if (value < 0 || value > 5) value = 0; course = value; }
	}
	public CStudentWithoutTeacher(string name, int age, int course) : base (name, age)
	{
		Course = course;
	}
	public void NewCourse()
	{
		if (course == 5) { course = 0; }
		else course++;
	}
	public override void Print()
    {
        base.Print();
		Console.WriteLine("Course - {0}", course);
	}

	public override string ToString()
	{
		string String = base.ToString() + " Course:" + course;
		return String;
	}

	public override bool Equals(Object obj)
	{
		if (obj == null || !(obj is CStudentWithoutTeacher))
			return false;
		else
			return (base.Equals(obj) && (course == ((CStudentWithoutTeacher)obj).course));
	}

	public override int GetHashCode()
	{
		int i = base.GetHashCode();
		return (i * 100) + course;
	}

	public override object Clone() => new CStudentWithoutTeacher(name, Age, course);
}
