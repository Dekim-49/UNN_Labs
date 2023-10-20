using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            menu:
            Console.WriteLine("\n1 - Task1");
            Console.WriteLine("2 - Task2");
            Console.WriteLine("3 - Task3");
            Console.WriteLine("4 - Task4");
            Console.WriteLine("6 - Task6");
            Console.WriteLine("7 - Task7");
            Console.WriteLine("8 - Выход");

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if ((choice > 8 || choice < 1) && choice != 5)
                {
                    Console.WriteLine("Неверный ввод!");
                }

            } while ((choice > 8 || choice < 1) && choice != 5);
            switch (choice)
            {
                case 1:
                    {
                        Task1();
                        goto menu;
                    }
                case 2:
                    {
                        Task2();
                        goto menu;
                    }
                case 3:
                    {
                        Task3();
                        goto menu;
                    }
                case 4:
                    {
                        Task4();
                        goto menu;
                    }
                case 6:
                    {
                        Task6();
                        goto menu;
                    }
                case 7:
                    {
                        Task7();
                        goto menu;
                    }
            }

            Console.ReadLine();
        }

        static void Task7()
        {
            Console.WriteLine("Введите количество элементов N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("#{0} = ", i + 1);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < n ; i++)
            {
                //if (i == 1 && array[i] == 0)
                //{
                //    array[i] = array[i - 1];
                //}
                if (array[i] == 0)
                {
                    array[i] = array[i - 1] + array[i - 2];
                }
            }

            for (int i = 0; i < n; i++)
                Console.Write(array[i] + " ");


        }
        static void Task6()
        {
            Console.WriteLine("Введите количество элементов N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("#{0} = ", i+1);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < n-1; i++)
            {
                if (Math.Abs(array[i+1]-array[i]) == 1)
                {
                    Console.WriteLine("Да, имеются");
                    break;
                }
                
                if (i == n-2) Console.WriteLine("Нет, не имеются");
            }
        }
        //static void Task5()
        //{
        //    int n = 10000; //100; // оно не работает на 100к, соре :(
        //    long[,] ar1 = new long[n, n];
        //    long[,] ar2 = new long[n, n];
        //    Random rand = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            ar1[i, j] = rand.Next(10);
        //            ar2[i, j] = rand.Next(10);
        //            Console.Write(ar1[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            Console.Write(ar2[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }

        //    //    //Метод Parallel.For позволяет выполнять итерации цикла параллельно
        //    //    //Первый параметр метода задает начальный индекс элемента в цикле, а второй параметр - конечный индекс. 
        //    //    //Третий параметр - делегат Action - указывает на метод, который будет выполняться один раз за итерацию
        //    //    long[,] result = new long[n, n];
        //    //    Parallel.For(0, n, i =>
        //    //    {
        //    //        for (int j = 0; j < n; ++j)
        //    //            for (int k = 0; k < n; ++k)
        //    //                result[i, j] += ar1[i,k] * ar2[k,j];
        //    //    }
        //    //    );

        //    //    Console.WriteLine();
        //    //    for (int i = 0; i < n; i++)
        //    //    {
        //    //        for (int j = 0; j < n; j++)
        //    //        {
        //    //            Console.Write(result[i, j] + " ");
        //    //        }
        //    //        Console.WriteLine();
        //    //    }
        //    //}

            static void Task4()
        {
            Console.Write("Введите количество рядов N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество мест в ряду M = ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                
                Array.Resize(ref array[i], m);
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Ряд {0}, место {1} = ", i+1, j+1);
                    array[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Write("Введите количество мест для брони K = ");
            int k = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= m-k; j++)
                {
                    //Мы смотрим часть массива и ищем вхождение "1" в него. Если "1" нет, значит все нули, значит все места свободны.
                    if (Array.IndexOf(array[i], 1, j, k) == -1)
                    {
                        Console.WriteLine("Ваш ряд: {0}", i+1);
                        break;
                    }
                }
            }
        }
        static void Task3()
        {
            int[][] arrays = new int[1][]; //Массив массивов пользователя

        menu:
                Console.WriteLine("");
                Console.WriteLine("1 - Инициализация массивa");
                Console.WriteLine("2 - Сложение двух массивов");
                Console.WriteLine("3 - Умножение массива на число");
                Console.WriteLine("4 - Поиск общих значений");
                Console.WriteLine("5 - Печать массива");
                Console.WriteLine("6 - Упорядочить по убыванию");
                Console.WriteLine("7 - Поиск мин, макс и среднего значения");
                Console.WriteLine("8 - Выход");

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 8 || choice < 1)
                {
                    Console.WriteLine("Неверный ввод!");
                }

            } while (choice > 8 || choice < 1);
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("---- Выбрано: 1 - Инициализация массивa");

                        if (arrays[0] != null)
                        {
                            Array.Resize(ref arrays, arrays.Length + 1);
                        }

                        Console.WriteLine("Введите размер массива");
                        int size = Convert.ToInt32(Console.ReadLine());
                        arrays[arrays.Length - 1] = Initialization(size);
                        Print(arrays[arrays.Length - 1]);
                        goto menu;

                    }
                case 2:
                    {
                        Console.WriteLine("---- Выбрано: 2 - Сложение двух массивов");
                        
                        Console.Write("Введите номер массива №1: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Введите номер массива №2: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int b = Convert.ToInt32(Console.ReadLine());

                        Sum(arrays[a - 1], arrays[b - 1]);
                        goto menu;
                    }
                case 3:
                    {
                        Console.WriteLine("---- Выбрано: 3 - Умножение массива на число");
                        Console.Write("Введите номер массива: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());
                       
                        Console.WriteLine("Введиет число, на которое нужно умножить массив: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");

                        Multiplication(arrays[a - 1], b);
                        goto menu;
                    }
                case 4:
                    {
                        Console.WriteLine("---- Выбрано: 4 - Поиск общих значений");

                        
                        Console.Write("Введите номер массива №1: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите номер массива №2: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int b = Convert.ToInt32(Console.ReadLine());

                        Find(arrays[a - 1], arrays[b - 1]);
                        goto menu;
                    }

                case 5:
                    {
                        //Console.WriteLine(arrays.Length);
                        Console.WriteLine("---- Выбрано: 5 - Печать массива");
                        Console.Write("Введите номер массива: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());

                        Print(arrays[a - 1]);
                        goto menu;
                    }
                case 6:
                    {
                        Console.WriteLine("---- Выбрано: 6 - Упорядочить по убыванию");
                        Console.Write("Введите номер массива: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());

                        SortDescending(arrays[a - 1]);
                        Print(arrays[a - 1]);
                        goto menu;
                    }
                case 7:
                    {
                        Console.WriteLine("---- Выбрано: 7 - Поиск мин, макс и среднего значения");
                        Console.Write("Введите номер массива: ");
                        for (int i = 0; i < arrays.Length; i++) Console.Write(i + 1 + " ");
                        Console.WriteLine("");
                        int a = Convert.ToInt32(Console.ReadLine());

                        MinMax(arrays[a - 1]);
                        goto menu;
                    }
                case 8:
                    {
                        break;
                    }
            }


            int[] Initialization(int size)
            {
                var rand = new Random();
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = rand.Next(100);
                }
                return array;
            }
            void Sum(int[] array1, int[] array2)
            {
                // Проверка на длину массивов
                if (array1.Length != array2.Length)
                {
                    Console.WriteLine("Массивы разных размеров");
                    return;
                }
                int[] s = new int[array1.Length];
                Console.Write("Cумма массивов: ");
                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = array1[i] + array2[i];
                    Console.Write(s[i] + " ");
                }
                return;
            }
            void Multiplication(int[] array, int num)
            {
                int[] s = new int[array.Length];
                Console.Write("Произведение массива и числа: ");
                for (int i = 0; i < array.Length; i++)
                {
                    s[i] = array[i] * num;
                    Console.Write(s[i] + " ");
                }
                return;
            }
            void Find(int[] array1, int[] array2)
            {
                // Прохожусь по всем элеменам певрого массива
                for (int i = 0; i < array1.Length; i++)
                {
                    //Если текущий элемент 1ого массива находится во втором массиве, то напечатать его 1 раз
                    if (Array.Exists(array2, p => p == array1[i]))
                    {
                        int find = Array.Find(array2, p => p == array1[i]);
                        Console.Write(find + " ");
                    }
                }
                return;
            }
            void Print(int[] array)
            {
                foreach(var i in array)
                {
                    Console.Write(i.ToString() + " ");
                }
                return;
            }
            void SortDescending(int [] array)
            {
                Array.Sort(array);
                Array.Reverse(array);
                return;
            }
            void MinMax(int[] array)
            {
                int[] copy = new int[array.Length];
                Array.Copy(array, copy, array.Length);
                Array.Sort(copy);
                int sum = 0;
                foreach (var i in copy) sum += i;
                Console.Write("Min = {0}\nMax = {1}\nСреднее значение = {2}", copy[0], copy[copy.Length-1], Convert.ToInt32(sum/copy.Length));
                return;
            }

        }
        static void Task2()
        {
            //Вводим размер начального массива N и его элементы
            Console.Write("Введите размер массива N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Введите число N[{0}] = ", i + 1);
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Ваш массив ");
            foreach (var v in num)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine("");

            Array.Reverse(num);

            Array.Reverse(num, 0, Convert.ToInt32(N / 2));

            if (N%2 == 0)
            {
                Array.Reverse(num, Convert.ToInt32(N / 2), Convert.ToInt32(N / 2));
            }
            else
            {
                Array.Reverse(num, Convert.ToInt32(N / 2), Convert.ToInt32(N / 2)+1);
            }


            Console.Write("Ваш перевёрнутый массив ");
            foreach (var v in num)
            {
                Console.Write(v.ToString() + " ");
            }
        }
        static void Task1()
        {

            // сдвиг старых эл-ов 

            //Вводим размер начального массива N и его элементы
            Console.Write("Введите размер массива N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Введите число N[{0}] = ", i + 1);
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Ваш массив ");
            foreach (var v in num)
            {
                Console.Write(v.ToString() + " ");
            }

            // Запрашиваем позицию К и проверяем, является ли она допустима
            Console.Write("\nВведите позицию K = ");
            int K = Convert.ToInt32(Console.ReadLine());
            while (K < 1 || K > N)
            {
                Console.Write("Недопустимая позиция\nВведите позицию K = ");
                K = Convert.ToInt32(Console.ReadLine());
            }

            // Запрашиваем количество новых элементов М
            Console.Write("Введите количество новых элементов M = ");
            int M = Convert.ToInt32(Console.ReadLine());
            int[] num1 = new int[M];
            for (int i = 0; i < M; i++)
            {
                Console.Write("Введите число N[{0}] = ", i + 1);
                num1[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Resize(ref num1, num1.Length + N-K+1);
            Array.Copy(num, K - 1, num1, M, N - K + 1);
            Array.Resize(ref num, N + M);
            
            //if (N < K + M)
            //{
            //    Array.Resize(ref num, (K + M)-1);
            //}
            Array.Copy(num1, 0, num, K-1, num1.Length);

            //for (int i = K - 1; i < K + M - 1; i++)
            //{
            //    // Запрашиваем элемент
            //    Console.WriteLine("Введите элемент #{0} = ", i - K + 2);
            //    int elem = Convert.ToInt32(Console.ReadLine());

            //    // Если не хватает места для добавления нового элемента, расширяем изначальный массив
            //    if (num.Length == i)
            //    {
            //        Array.Resize(ref num, num.Length + 1);
            //    }
            //    num[i] = elem;
            //}

            Console.Write("Ваш массив ");
            foreach (var v in num)
            {
                Console.Write(v.ToString() + " ");
            }
        }
    }
}
