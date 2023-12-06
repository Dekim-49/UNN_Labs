using System;

public class CTeacher : CPerson
{
	CStudentWithoutTeacher[] studentsGroup;
	public CTeacher(string name, int age, CStudentWithoutTeacher[] group) : base(name, age)
	{
		studentsGroup = group;
	}

	public override void Print()
    {
		base.Print();
		Console.WriteLine("Group");
		for (int i = 0; i < studentsGroup.Length; i++)
        {
			Console.WriteLine("Student #{0} - {1}", i+1, studentsGroup[i].name);
        }
    }

    public override string ToString()
    {
		string String;
		string h = "";
		for (int i = 0; i < studentsGroup.Length; i++)
        {
			h += studentsGroup[i].name + " ";
		}
		String = base.ToString() + " Group:" + h;
		return String;

	}

	public override bool Equals(Object obj)
	{
		if (obj == null || !(obj is CTeacher))
			return false;
		else
			return (base.Equals(obj) && (studentsGroup == ((CTeacher)obj).studentsGroup));
	}

	public override int GetHashCode()
	{
		int i = base.GetHashCode();
		return (i * 1000) + studentsGroup.Length;
	}

	public static CTeacher RandomTeacher(Object[] obj)
	{
		Random random = new Random();
		System.Threading.Thread.Sleep(500);
		int i = random.Next(obj.Length - 1);

        while (!(obj[i] is CTeacher))
        {
            //System.Threading.Thread.Sleep(500);
            i = random.Next(obj.Length - 1);
        }
        return (CTeacher)obj[i];
	}


	public override object Clone() => new CTeacher(name, Age, studentsGroup);
}
