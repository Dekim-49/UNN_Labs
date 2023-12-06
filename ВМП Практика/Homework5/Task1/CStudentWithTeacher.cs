using System;

public class CStudentWithTeacher : CStudentWithoutTeacher
{
	CTeacher teacher;


	public CStudentWithTeacher(string name, int age, int course, CTeacher t) : base(name, age, course)
	{
		teacher = t;
	}

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Teacher - {0}", teacher.name);
    }

    public override string ToString()
    {
        string String = base.ToString() + " Teacher:" + teacher.name; 
        return String;
    }

	public override bool Equals(Object obj)
	{
		if (obj == null || !(obj is CStudentWithTeacher))
			return false;
		else
			return (base.Equals(obj) && (teacher == ((CStudentWithTeacher)obj).teacher));
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static CStudentWithTeacher RandomStudent(Object[] obj)
	{
		Random random = new Random();
		System.Threading.Thread.Sleep(500);
		int i = random.Next(obj.Length - 1);

		while (!(obj[i] is CStudentWithTeacher))
		{
			//System.Threading.Thread.Sleep(500);
			i = random.Next(obj.Length - 1);
		}
		return (CStudentWithTeacher)obj[i];
	}

	public override object Clone() => new CStudentWithTeacher(name, Age, Course, teacher);
}
