using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework5
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - задание 1\n2 - задание 2\n3 - задание 3");
            Console.Write("Chouse = ");
            int Chouse = Convert.ToInt32(Console.ReadLine());
            if (Chouse == 1)
            {
                //вначале зачисляем студентов
                // потом преподов, формируем группы каждого препода
                // потом студентам назначаем их препода
                //    Создаём новые группы студентов, чтобы потом закрепить группу за учителем

                //Группа 1
                CStudentWithoutTeacher[] group_1 = new CStudentWithoutTeacher[5];
                group_1[0] = new CStudentWithoutTeacher("Tom", 18, 1);
                group_1[1] = new CStudentWithoutTeacher("Sandy", 19, 1);
                group_1[2] = new CStudentWithoutTeacher("Andry", 18, 1);
                group_1[3] = new CStudentWithoutTeacher("Marin", 18, 1);
                group_1[4] = new CStudentWithoutTeacher("Lisa", 18, 1);

                // Учитель первой группы
                CTeacher teacher_1 = new CTeacher("Mr.Damboldor", 42, group_1);

                Console.WriteLine("Студенты первой группы:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0} ", i + 1);
                    group_1[i].Print();
                    Console.Write("\n");
                }
                Console.WriteLine("Преподаватель:");
                teacher_1.Print();
                Console.WriteLine("===============================================\n");


                //Группа 2
                CStudentWithoutTeacher[] group_2 = new CStudentWithoutTeacher[6];
                group_2[0] = new CStudentWithoutTeacher("Garry", 20, 3);
                group_2[1] = new CStudentWithoutTeacher("Vanessa", 21, 3);
                group_2[2] = new CStudentWithoutTeacher("Olya", 20, 3);
                group_2[3] = new CStudentWithoutTeacher("Misha", 21, 3);
                group_2[4] = new CStudentWithoutTeacher("Vasyz", 20, 3);
                group_2[5] = new CStudentWithoutTeacher("Colins", 21, 3);

                // Учитель второй группы
                CTeacher teacher_2 = new CTeacher("Mr.Echpochmak", 37, group_2);

                Console.WriteLine("Студенты второй группы:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0} ", i + 1);
                    group_1[i].Print();
                    Console.Write("\n");
                }
                Console.WriteLine("Преподаватель:");
                teacher_1.Print();
                Console.WriteLine("===============================================\n");

                //Группа 3
                CStudentWithoutTeacher[] group_3 = new CStudentWithoutTeacher[3];
                group_3[0] = new CStudentWithoutTeacher("Sofi", 18, 4);
                group_3[1] = new CStudentWithoutTeacher("Lores", 19, 4);
                group_3[2] = new CStudentWithoutTeacher("Kosiposha", 18, 4);


                // Учитель третьей группы
                CTeacher teacher_3 = new CTeacher("Mrs.GranatoviySok", 37, group_3);

                Console.WriteLine("Студенты третьей группы:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0} ", i + 1);
                    group_1[i].Print();
                    Console.Write("\n");
                }
                Console.WriteLine("Преподаватель:");
                teacher_1.Print();
                Console.WriteLine("===============================================\n");

                // Присваиваем каждому студенту своего преподавателя
                CStudentWithTeacher[] studentMassiv = new CStudentWithTeacher[3 + 6 + 5];

                for (int i = 0; i < 5; i++)
                {
                    studentMassiv[i] = new CStudentWithTeacher(group_1[i].name, group_1[i].Age, group_1[i].Course, teacher_1);
                }
                for (int i = 0; i < 6; i++)
                {
                    studentMassiv[i + 5] = new CStudentWithTeacher(group_2[i].name, group_2[i].Age, group_2[i].Course, teacher_2);
                }
                for (int i = 0; i < 3; i++)
                {
                    studentMassiv[i + 5 + 6] = new CStudentWithTeacher(group_3[i].name, group_3[i].Age, group_3[i].Course, teacher_3);
                }


                // Создаём массив Person и заполняем его персонами, студентами и учителями в рандомном порядке


                CPerson[] Person = new CPerson[]
                {
                new CPerson("Valera", 45),
                studentMassiv[0],
                studentMassiv[1],
                studentMassiv[2],
                studentMassiv[3],
                studentMassiv[4],
                teacher_1,
                studentMassiv[5],
                studentMassiv[6],
                studentMassiv[7],
                teacher_2,
                new CPerson("Vitya", 88),
                studentMassiv[8],
                studentMassiv[9],
                studentMassiv[10],
                new CPerson("Oleg", 52),
                studentMassiv[11],
                studentMassiv[12],
                studentMassiv[13],
                new CPerson("Marina", 12),
                teacher_3
                };


                Console.WriteLine("Массив типа Person");
                for (int i = 0; i < Person.Length; i++)
                {
                    Console.WriteLine("#{0}", i + 1);
                    Person[i].Print();
                    Console.WriteLine();
                }
                Console.WriteLine("===============================================");
                Console.WriteLine("Реализация метода ToString()\nМетод выводит в одну строку параметры экземпляра класса");
                Console.WriteLine("===============================================\n");
                Console.WriteLine("Для Person: {0}", Person[0].ToString());
                Console.WriteLine("Для Student: {0}", Person[1].ToString());
                Console.WriteLine("Для Teacher: {0}", Person[6].ToString());

                Console.WriteLine("\n===============================================");
                Console.WriteLine("Реализация метода Equals()\nМетод определяет, равен ли заданный объект текущему объекту");
                Console.WriteLine("===============================================\n");
                Console.Write("Равны ли CPerson(\"Valera\", 45) и CPerson(\"Valera\", 45)? - - - ");
                if (Person[0].Equals(Person[0])) Console.WriteLine("Да"); else Console.WriteLine("Нет");
                Console.Write("Равны ли CPerson(\"Valera\", 45) и CPerson(\"Vitya\", 88)? - - - ");
                if (Person[0].Equals(Person[11])) Console.WriteLine("Да"); else Console.WriteLine("Нет");
                Console.Write("Равны ли CPerson(\"Valera\", 45) и CStudentWithoutTeacher(\"Tom\", 18, 1)? - - - ");
                if (Person[0].Equals(Person[1])) Console.WriteLine("Да"); else Console.WriteLine("Нет");
                Console.Write("Равны ли CPerson(\"Valera\", 45) и CTeacher(\"Mrs.GranatoviySok\", 37, group_3)? - - - ");
                if (Person[0].Equals(Person[20])) Console.WriteLine("Да"); else Console.WriteLine("Нет");
                Console.Write("Равны ли CStudentWithoutTeacher(\"Tom\", 18, 1) и CStudentWithoutTeacher(\"Tom\", 18, 1)? - - - ");
                if (Person[1].Equals(Person[1])) Console.WriteLine("Да"); else Console.WriteLine("Нет");
                Console.Write("Равны ли CStudentWithoutTeacher(\"Tom\", 18, 1) и CTeacher(\"Mrs.GranatoviySok\", 37, group_3)? - - - ");
                if (Person[1].Equals(Person[20])) Console.WriteLine("Да"); else Console.WriteLine("Нет");


                Console.WriteLine("\n===============================================");
                Console.WriteLine("Реализация метода GetHashCode()\nМетод определяет хэш-код");
                Console.WriteLine("===============================================\n");

                Console.WriteLine("Для Person - Длина имени * 1000 + возраст");
                Console.WriteLine("     Person[0] = {0}", Person[0].GetHashCode());
                Console.WriteLine("     Person[11] = {0}", Person[11].GetHashCode());
                Console.WriteLine("     Person[15] = {0}", Person[15].GetHashCode());
                Console.WriteLine("     Person[19] = {0}", Person[19].GetHashCode());
                Console.WriteLine("Для Students - (Длина имена * 1000 + возраст) * 1000 + номер курса");
                Console.WriteLine("     Person[1] = {0}", Person[1].GetHashCode());
                Console.WriteLine("     Person[2] = {0}", Person[2].GetHashCode());
                Console.WriteLine("     Person[3] = {0}", Person[3].GetHashCode());
                Console.WriteLine("     Person[4] = {0}", Person[4].GetHashCode());
                Console.WriteLine("Для Teacher - (Длина имена * 1000 + возраст) * 1000 + количество студентов в группе");
                Console.WriteLine("     Person[6] = {0}", Person[6].GetHashCode());
                Console.WriteLine("     Person[10] = {0}", Person[10].GetHashCode());
                Console.WriteLine("     Person[20] = {0}", Person[20].GetHashCode());

                Console.WriteLine("\n===============================================");
                Console.WriteLine("Реализация методов RandomPerson, RandomStudent, RandomTeacher");
                Console.WriteLine("===============================================\n");

                Console.WriteLine("Пять вызовов RandomPerson:");
                for (int i = 0; i < 5; i++) Console.WriteLine(CPerson.RandomPerson(Person));

                Console.WriteLine("\n------------------------------------------------\n");

                Console.WriteLine("Пять вызовов RandomStudent:");
                for (int i = 0; i < 5; i++) Console.WriteLine(CStudentWithTeacher.RandomStudent(Person));

                Console.WriteLine("\n------------------------------------------------\n");

                Console.WriteLine("Пять вызовов RandomTeacher:");
                for (int i = 0; i < 5; i++) Console.WriteLine(CTeacher.RandomTeacher(Person));

                Console.WriteLine("\n===============================================");
                Console.WriteLine("Количество классов в массиве Person");
                Console.WriteLine("===============================================\n");

                int countPerson = 0;  //Количество Персонов
                int countStudent = 0; //Количество Студентов
                int countTeacher = 0; //Количество Учителей

                for (int i = 0; i < Person.Length; i++)
                {
                    if ((Person[i].GetType()).FullName == "CPerson") countPerson++;
                    if (Person[i] is CTeacher) countTeacher++;
                    if (Person[i] is CStudentWithTeacher) // Переводим студентов на новый курс
                    {
                        CStudentWithTeacher cswt = Person[i] as CStudentWithTeacher;
                        cswt.NewCourse();
                        countStudent++;
                    }
                }
                Console.WriteLine("Person = {0}     Students = {1}     Teacher = {2}", countPerson, countStudent, countTeacher);

                Console.WriteLine("\n===============================================");
                Console.WriteLine("Клонирование с помощью метода Clone");
                Console.WriteLine("===============================================\n");

                Console.WriteLine("Для Person:");
                var p_1 = (CPerson)Person[0].Clone();
                Console.WriteLine(p_1.GetType());
                p_1.Print();
                Console.WriteLine("\n------------------------------------------------\n");

                Console.WriteLine("Для Student:");
                var p_2 = (CStudentWithTeacher)Person[1].Clone();
                Console.WriteLine(p_2.GetType());
                p_2.Print();
                Console.WriteLine("\n------------------------------------------------\n");

                Console.WriteLine("Для Teacher:");
                var p_3 = (CTeacher)Person[6].Clone();
                Console.WriteLine(p_3.GetType());
                p_3.Print();

                Console.WriteLine("\n===============================================");
                Console.WriteLine("Иерархия классов");
                Console.WriteLine("===============================================\n");

                var b = new Program();
                Console.WriteLine("Для Person:");
                b.ClassParents(Person[0]);
                Console.WriteLine("\n------------------------------------------------\n");
                Console.WriteLine("Для Student:");
                b.ClassParents(Person[1]);
                Console.WriteLine("\n------------------------------------------------\n");
                Console.WriteLine("Для Teacher:");
                b.ClassParents(Person[6]);

                Console.WriteLine("===============================================\n");
            }
            if (Chouse == 2)
            {
                Book[] books = new Book[5];
                books[0] = new BookGenrePubl("Война и мир", "Лев Толстой", 350, "Драма", "Эксмо");
                books[1] = new BookGenrePubl("Демон", "михаил Лермонстов", 270, "Поэма", "Лабиринт");
                books[2] = new BookGenrePubl("Колобок", "русская народная",  120 , "Сказка", "Эксмо");
                books[3] = new BookGenrePubl("Дом в котором...", "Мариам Петросян", 1650, "Фикшн", "Лабиринт");
                books[4] = new BookGenrePubl("Пегас, Лев и Кентавр", "Дмитрий Емец", 470, "Фэнтези", "Лабиринт");

                for (int i = 0; i < 5; i++)
                {
                    books[i].Print();
                    Console.WriteLine();
                }
            }
            if (Chouse == 3)
            {
                Triangle triangle_1 = new TriangleColor("Triangle", 3, 4, 5, "red");
                Console.WriteLine("Area = " + triangle_1.Area());
                triangle_1.Print();

                Triangle triangle_2 = new TriangleColor("Triangle", 4, 5, 6, "blue");
                Console.WriteLine("Area = " + triangle_2.Area());
                triangle_2.Print();

            }
            Console.ReadLine();
        }

        void ClassParents(Object obj)
        {
            var derived = obj.GetType();
            Console.WriteLine("Класс: {0}", derived.FullName);
            do
            {
                derived = derived.BaseType;
                if (derived != null)
                    Console.WriteLine("Предок: {0}", derived.FullName);
            }
            while (derived != null);
        }
    }
}
