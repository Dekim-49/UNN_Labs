using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        // Задание №1
        static public void Task_1()
        {
            //Ввод чисел с консоли
            Console.Write("Введите число num1 = ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число num2 = ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число num3 = ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Вы ввели:\nnum1 = {0}\nnum2 = {1}\nnum3 = {2}", +num1, +num2, +num3);
            
            // Поиск максимума
            if (num1 > num2) Console.WriteLine("Максимум из num1 и num2 это {0}", num1);
            else Console.WriteLine("Максимум из num1 и num2 это {0}", num2);
            if (num2 > num3) Console.WriteLine("Максимум из num2 и num3 это {0}", num2);
            else Console.WriteLine("Максимум из num2 и num3 это {0}", num3);
            if (num3 > num1) Console.WriteLine("Максимум из num3 и num1 это {0}", num3);
            else Console.WriteLine("Максимум из num3 и num1 это {0}", num1);
        }
        // Задание №2
        static public void Task_2()
        {
            //Ввод чисел с консоли
            Console.Write("Введите число num1 = ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            // Поиск делителей и вывод на консоль
            Console.Write("Делители вашего числа: ");
            for (int i = 1; i < 11; i++)
            {
                if (num1 % (i) == 0) Console.Write("{0}, ", i);
            }
        }
        // Задание №3
        static public void Task_3()
        {
            //Ввод чисел с консоли
            Console.Write("Введите сторону треугольника num1 = ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сторону треугольника num2 = ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сторону треугольника num3 = ");
            int num3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы ввели:\nnum1 = {0}\nnum2 = {1}\nnum3 = {2}", +num1, +num2, +num3);


            if (!((num1 + num2 > num3) && (num1 + num3 > num2) && ( num2 + num3 > num1))) Console.WriteLine("Это не треугольник");
            else
            {
                if (num1 == num2 || num1 == num3 || num2 == num3)
                {
                    if (num1 == num2 && num1 == num3 && num2 == num3) Console.WriteLine("Это равносторонний треугольник");
                    else Console.WriteLine("Это равнобедренный треугольник");
                }
                else
                {
                    if (num1 * num1 + num2 * num2 == num3 * num3 || num1 * num1 + num3 * num3 == num2 * num2 || num3 * num3 + num2 * num2 == num1 * num1)
                        Console.WriteLine("Это прямоугольный треугольник");
                    else Console.WriteLine("Это обычный треугольник");
                }
            }
        }
        // Задание №4
        static public void Task_4()
        {
            int i = 0;
            while (i != 21)
            {
                Console.WriteLine("Степень {0}: {1}", i, Math.Pow(2, i));
                i++;
            }
        }
        // Задание №5
        static public void Task_5()
        {
            Console.Write("Введите число num1 = ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int evenCount = 0, notevenCount = 0; ;

            for (int i = 1; i <= num1; i++)
            {
                if (i % 2 == 0) evenCount++;
                else notevenCount++;
            }
            Console.WriteLine("Количество чётных чисел: {0}\nКоличество нечётных: {1}", evenCount, notevenCount);
        }
        // Задание №6
        static public void Task_6()
        {
            Console.Write("Введите число num1 = ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число num2 = ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            
            //Проверка: первое число должно быть меньше
            if (num1 > num2)
            {
                int i = num1;
                num1 = num2;
                num2 = i;
            }
            int count3 = 0, count5 = 0, count9 = 0;
            for (int i = num1; i <= num2; i++)
            {
                if (i % 3 == 0) count3++;
                if (i % 5 == 0) count5++;
                if (i % 9 == 0) count9++;
            }
            Console.WriteLine("Кол-во чисел, делящихся на 3: {0}\nКол-во чисел, делящихся на 5: {1}\nКол-во чисел, делящихся на 9: {2}", count3, count5, count9);
        }
        // Задание №7
        static public void Task_7()
        {
            int max = 0, medium = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Введите число #{0} = ", i+1);
                int num = Convert.ToInt32(Console.ReadLine());
                if (max < num) max = num;
                medium += num;
            }
            Console.Write("Максимум: {0}\nСреднее арифметическое: {1}", max, medium/10);
        }
        // Задание №8
        static public void Task_8()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 50);
            int userNumber = 0;
            int count = 1;

            Console.Write("Введите число = ");
            userNumber = Convert.ToInt32(Console.ReadLine());
            while (userNumber!= randomNumber)
            {
                count++;
                if (userNumber > randomNumber) Console.WriteLine("Ваше число больше загаданного");
                else Console.WriteLine("Ваше число меньше загаданного");

                Console.Write("Введите число = ");
                userNumber = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Поздравляем! Вы отгадали число за {0} попыток", count);
        }
        // Задание №9
        static public void Task_9()
        {
            Random rnd = new Random();
            int orel = 0;
            for (int i = 0; i < 100; i++)
            {
                int randomNumber = rnd.Next(2);
                if (randomNumber == 1) orel++;
            }
            Console.Write("Орёл выпал {0} раз\nРешка выпала {1} раз", orel, 100 - orel);
        }

        static void Main(string[] args)
        {
            //Task_1();
            //Task_2();
            //Task_3();
            //Task_4();
            //Task_5();
            //Task_6();
            //Task_7();
            //Task_8();
            //Task_9();
  
            Console.ReadLine();
        }
    }
}
