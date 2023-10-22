using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    { 
        static void Main(string[] args)
        {
        menu:
            Console.WriteLine("\n1 - Task1");
            Console.WriteLine("2 - Task2. Курьер развозит одну пиццу.");
            Console.WriteLine("3 - Task3");
            Console.WriteLine("4 - Выход");

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if ((choice > 4 || choice < 1))
                {
                    Console.WriteLine("Неверный ввод!");
                }

            } while ((choice > 4 || choice < 1));
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
            }
            Console.ReadLine();
        }

        static void Task3()
        {
            Massiv massiv1 = new Massiv(7);
            massiv1.InputData();

            Massiv massiv2 = new Massiv(7);
            massiv2.InputDataRandom();
            
            Console.WriteLine();
            massiv1.Print(0, 7);
            Console.WriteLine();
            massiv2.Print(0, 7);
            Console.WriteLine();


            int[] ar = massiv1.FindValue(3);
            foreach(var v in ar) Console.Write(v + " ");
            Console.WriteLine();

            ar = massiv2.FindValue(3);
            foreach (var v in ar) Console.Write(v + " ");
            Console.WriteLine();


            massiv1.DelValue(1);
            massiv1.Print(0, 7);
            Console.WriteLine();

            massiv2.DelValue(1);
            massiv2.Print(0, 7);
            Console.WriteLine();


            int max;
            massiv1.FindMax(out max);
            Console.WriteLine(max);
            massiv2.FindMax(out max);
            Console.WriteLine(max);

            massiv1.Add(massiv2.array);
            Console.WriteLine();
            massiv1.Sort(ref massiv1.array);
        }
        class Massiv
        {
            public int size;
            public int[] array;
            public Massiv(int size)
            {
                this.size = size;
                array = new int[size];
            }
            public void InputData()
            {
                //array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    Console.Write("Введите значение array[{0}] = ", i);
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            public void InputDataRandom()
            {
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                }
            }
            public void Print(in int indexFirst, in int indexLast)
            {
                for (int i = indexFirst; i < indexLast; i++) Console.Write(array[i] + " ");
            }
            public int[] FindValue(in int elem)
            {
                int count = 0;
                int[] index = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == elem) index[count++] = i;
                }
                return index;
            }
            public void DelValue(in int elem)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == elem)
                    {
                        for (int j = i; j < array.Length-1; j++)
                        {
                            array[j] = array[j + 1];
                            if (j == array.Length-1) array[j] = 0;
                        }
                    }
                }
            }
            public void FindMax(out int max)
            {
                max = 0;
                foreach(var v in array)
                {
                    if (max < v) max = v;
                }
            }
            public void Add(int[] array2)
            {
                if(array.Length == array2.Length)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write((array[i] + array2[i]) + " ");
                    }
                }
            }
            public void Sort(ref int[]array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length-1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            int x = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = x;
                        }
                    }
                }
            }


        }

        static void Task2()
        {
            Console.Write("Введите количество пекарей n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество курьеров m = ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите вместимость склада t = ");
            int t = Convert.ToInt32(Console.ReadLine());



            Random rdn = new Random();
            //инициализация массивов пекарей, курьеров и склада
            Baker[] bakers = new Baker[n];
            for (int i = 0; i < n; i++)
            { 
                //рандом используется для заказов, дистанции.
                //Создаем пекарей с номерами и их скоростью
                bakers[i] = new Baker(i+1, rdn.Next(1, 20));
            }

            Courier[] couriers = new Courier[m];
            for (int i = 0; i < m; i++)
            {
                //Создаем курьера
                couriers[i] = new Courier(i+1);
            }
            
            int[] Storage = new int[t];
            for (int i = 0; i < t; i++) Storage[i] = 0;

            // Массив заказов
            Order[] orders = new Order[1];

            int maxWork = 35; // максимльное число тактов на один заказ. Если заказ превысил это число - пиица бесплатно
            int maxBake = 15; //максимальное врмея для пекаря.
            int[] sale = new int[1] { maxWork };

            int countDay = 0; // количество проданных пицц
            int countPizza = 0; //Количество сделанных пицц
            bool storagebig = false; //надо ли расширять склад
            bool ordersmol = false; //надо ли брать меньше заказов.
            //i - минуты. Пусть рабочий день 3 часов, т.е. 180 минут
            //заказы на пиццу поступают ежеминутно.


            int Smena = 480; //количество тактов времени
            
            //Пока не кончилась смена, работаем по тактам
            for (int time = 0; time < Smena; time++)
            {
                   Console.WriteLine("\n\nВремя №{0}: ----------------------------------------", time+1);
                   //Имитация внезапного заказа. Если рандом 1, то поступил новый заказ.
                   //Создаётся новый заказ с номером и расстоянием до заказчика, определяемое рандомом. 
                Random rdn1 = new Random();
                if (rdn1.Next(0, 2) == 1)
                {
                    countPizza++;
                   // Расширяем массив заказов
                    Array.Resize(ref orders, orders.Length + 1);
                    Array.Resize(ref sale, sale.Length + 1);
                    sale[sale.Length - 1] = maxWork;
                    //фиксируем новый заказ, даем ему номер и пишем дистанцию до пункта заказа.
                    Random rdn2 = new Random();
                    orders[orders.Length - 2] = new Order(countPizza, rdn2.Next(1, 30));
                    Console.WriteLine("Заказ №{0}: поступил в обработку", orders.Length - 1);

                    //Если время доставки позднее, то заказ отменяется
                    //подумать!!!!!!!!!!
                    if (time + orders[orders.Length - 2].distanc > Smena)
                    {
                        orders[orders.Length - 2].status = 6;
                        Console.WriteLine("Заказ №{0}: отклонён", orders.Length - 1);
                        countPizza--;
                    }
                }

                if (orders.Length > 1)
                {
                    // Проверка по каждому существующему заказу
                    for (int ordernumber = 1; ordernumber < orders.Length; ordernumber++)
                    {
                        //Если заказ находится в обработке
                        if (orders[ordernumber-1].status == 0)
                        {
                            //Ищем свободного пекаря
                            for (int i = 0; i < n; i++)
                            {
                                if (bakers[i].status == -2)
                                {
                                    bakers[i].GetOrder(ordernumber);
                                    orders[ordernumber - 1].status = 1;
                                    sale[ordernumber - 1] -= bakers[i].speed;
                                    Console.WriteLine("Заказ №{0}: готовится. Будет готов через {1} тактов", ordernumber, bakers[i].speed);
                                    if (bakers[i].speed > maxBake) bakers[i].work--;
                                    else bakers[i].work++;
                                    break;
                                }

                                //Если заказ есть, а ни одного пекаря нет - надо уменьшит кол-во заказов
                                if (i == n - 1) ordersmol = true;
                            }
                        }
                        //Если заказ готовится
                        if (orders[ordernumber - 1].status == 1)
                        {
                            //Если заказ готов......
                            if (Array.Find(bakers, p => p.numberOrder == ordernumber) != null)
                            {
                                if (Array.Find(bakers, p => p.numberOrder == ordernumber).IsDone())
                                {
                                    Array.Find(bakers, p => p.numberOrder == ordernumber).status = -1;
                                    Console.WriteLine("Заказ №{0}: отправляется на склад", ordernumber);
                                    orders[ordernumber - 1].status = 2;
                                }
                                else
                                {
                                    Array.Find(bakers, p => p.numberOrder == ordernumber).status--;
                                }
                            }
                            
                        }
                        //Если заказ пытаются определить на склад
                        if (orders[ordernumber - 1].status == 2)
                        {
                            // .....то пекарь его пытается положить на склад. Если положил, меняем статус заказа
                            if (Array.Find(bakers, p => p.numberOrder == ordernumber).InStorage(ref Storage, ordernumber))
                            {
                                Console.WriteLine("Заказ №{0}: на складе", ordernumber);
                                orders[ordernumber - 1].status = 3;
                            }
                            //Если в склад не могут определить продукцию, то склад надо расширять.
                            else
                            {
                                storagebig = true;
                            }
                        }
                        // Если заказ на складе
                        if (orders[ordernumber - 1].status == 3)
                        {
                            //  Ищем свободного курьера
                            for (int i = 0; i < m; i++)
                            {
                                if (couriers[i].status == 0)
                                {
                                    sale[ordernumber - 1] -= orders[ordernumber - 1].distanc;
                                    //отдает курьеру заказ
                                    couriers[i].GetOrder(ordernumber, orders[ordernumber - 1].distanc);
                                    //меняем статус заказа
                                    orders[ordernumber - 1].status = 4;
                                    //освобождаем место на складе
                                    Storage[Array.IndexOf(Storage, ordernumber)] = 0;
                                    //выводим сообщение
                                    Console.WriteLine("Заказ №{0}: в пути. Если вам доставят позже {1} тактов, то пицца бесплатно!", ordernumber, maxWork);
                                    break;
                                }
                            }
                        }
                        //Если заказ у курьера
                        if (orders[ordernumber - 1].status == 4)
                        {
                            // Если курьер довз заказ
                            if (Array.Find(couriers, p => p.numberOrder == ordernumber) != null)
                            {
                                if (Array.Find(couriers, p => p.numberOrder == ordernumber).IsDoneToOrder(orders[ordernumber - 1].distanc) == true)
                                {
                                    Array.Find(couriers, p => p.numberOrder == ordernumber).distance = orders[ordernumber - 1].distanc;

                                    if (sale[ordernumber - 1] < 0)
                                    {
                                        Console.WriteLine("Заказ №{0}: Прибыл. Вам досталась бесплатная пицца. Приятного аппетита", ordernumber);
                                        Array.Find(couriers, p => p.numberOrder == ordernumber).work--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Заказ №{0}: Прибыл. Приятного аппетита", ordernumber);
                                        Array.Find(couriers, p => p.numberOrder == ordernumber).work++;
                                        countDay++;

                                    }
                                    orders[ordernumber - 1].status = 5;

                                }
                                else
                                {
                                    Array.Find(couriers, p => p.numberOrder == ordernumber).distance--;
                                }
                            }
                            
                        }

                        if (orders[ordernumber - 1].status == 5)
                        {
                            //Курьер едет назад
                            if (Array.Find(couriers, p => p.numberOrder == ordernumber).IsDoneToPizzaria() == true)
                                orders[ordernumber - 1].status = 6;
                        }

                        //if (orders[ordernumber].status == 6)

                        //мы спрашиваем у пекарей, возьмутся ли они за заказ.

                        //Смотрим, есть ли пиццы на складе. Если да, то есть ли курьеры. 
                        // Если нет, то ждем. Если есть курьеры, то развозим. Если нет, ждём.


                    }
                }

                //Паузная вещь для красоты
                //System.Threading.Thread.Sleep(1000);
                //Console.Clear();

            }
            Console.WriteLine("\n\n---------Итоги---------");
            Console.WriteLine("Сделано пицц: {0}", countPizza);
            Console.WriteLine("Продано пицц: {0}", countDay); 
            if (storagebig == true)
            {
                Console.WriteLine("Склад: Необходимо увеличить размер склада");
            }
            if (ordersmol == true)
            {
                Console.WriteLine("Заказы: Необходимо уменьших количество заказов");
            }
            else
            {
                Console.WriteLine("Заказы: Необходимо увеличить количество заказов");
            }
            Console.WriteLine("Пекари:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Номер: " + bakers[i].name + " Статус: ");
                if (bakers[i].work < 0) Console.WriteLine("уволить");
                else Console.WriteLine("нанять");
            }
            Console.WriteLine("Курьеры:");
            for (int i = 0; i < m; i++)
            {
                Console.Write("Номер: " + couriers[i].name + " Статус: ");
                if (couriers[i].work < 0) Console.WriteLine("уволить");
                else Console.WriteLine("нанять");
            }


        }
        struct Order
        {
            public int name;
            public int distanc;
            public int status; 
            /// <summary>
            /// Статусы:
            /// 0 - поступил в обработку
            /// 1 - принят, готовится
            /// 2 - сделан. идёт на склад
            /// 3 - на складе. ждет курьера
            /// 4 - в пути
            /// 5 - прибыл
            /// 6 - отклонён.
            /// 
            /// </summary>
          
            public Order(int name, int distanc)
            {
                this.name = name;
                this.distanc = distanc;
                this.status = 0;
            }
           
        }
        class Courier
        {
            public int name; // имя
            public int status = 0; // статус: в пути туда - 1, свободен - 0.
            public int distance; //его путь
            public int numberOrder;
            public int work = 0; //Если >0, то нанять, если <0, то уволить
            //Каждый +1 за доставку без задержек и -1 с
            public Courier(int name)
            {
                this.name = name;
                this.distance = 0;
               // Console.WriteLine("Курьер {0} нанят", this.name);
            }
            public void GetOrder(int numberOrder, int distance)
            {
                status = 1;
                this.distance = distance;
                this.numberOrder = numberOrder;
                //Console.WriteLine("Курьер {0} взял заказ номер {1} на дситанцию {2}", this.name, this.numberOrder, this.distance);
            }
            public bool IsDoneToOrder(int distance)
            {
                if (this.distance != 0)
                {
                    //Console.WriteLine("Курьер {0} с заказом {1} еще в пути . . .", this.name, this.numberOrder);
                    //this.distance--;
                    return false;
                }
                else
                {
                    //Console.WriteLine("Курьер {0} с заказом {1} прибыл на место назначение", this.name, this.numberOrder);
                    //this.distance = distance;
                    return true;
                }
            }
            public bool IsDoneToPizzaria()
            {
                if (distance != 0)
                {
                    //Console.WriteLine("Курьер {0} едет назад", this.name);

                    distance--;
                    return false;
                }
                else
                {
                    //Console.WriteLine("Курьер {0} приехал в пиццерию", this.name);
                    status = 0;
                    return true;
                }
            }

        }
        class Baker
        {
            //Пекарь: берет заказ, делает пиццу, несет пиццу на склад.
            // имя
            public int name; // имя
            public int speed; // опыт работы, т.е. скорость изготовления пиццы
            public int status; // -2 - свободе, -1 - он на складе
            public int numberOrder; //номер взятого заказа
            public int work = 0;
            public Baker(int name, int speed)
            {
                this.name = name;
                this.speed = speed;
                status = -2;
                //Console.WriteLine("Пекарь {0} нанят со стажем {1}", this.name, this.speed);
            }
            //Взять заказ на пиццу
            public void GetOrder(int numberOrder)
            {
                status = speed;
                this.numberOrder = numberOrder;
                //Console.WriteLine("Пекарь {0} взял заказ номер {1} и сделает его через {2}", this.name, this.numberOrder, status);
            }
            //Спрашиваем пекаря, готова ли пицца
            public bool IsDone()
            {
                if (status!=0)
                {
                    //Console.WriteLine("Пекарь {0} готовит заказ {1}", this.name, this.numberOrder);

                    //status--;
                    return false;
                }
                else
                {
                    //Console.WriteLine("Пекарь {0} сделал заказ {1} и несет его на склад", this.name, this.numberOrder);

                    //status = -1;
                    return true;
                }
            }
            //Пекарь пытается положить пиццу на склад
            public bool InStorage(ref int[] storage, int numberOrder)
            {
                if (Array.IndexOf(storage, 0) != -1)
                {
                    //Console.WriteLine("Пекарь {0} отнёс заказ {1} на склад", this.name, this.numberOrder);

                    storage[Array.IndexOf(storage, 0)] = numberOrder;
                    status = -2;
                    return true;
                }
                else
                {
                    //Console.WriteLine("Пекарь {0} ждёт пока склад освободится, чтобы положить заказ {1}", this.name, this.numberOrder);
                    return false;
                }
            }

        }

        static void Task1()
        {
            char[] charSeparators = new char[] { ' ' };

            Console.Write("Введите количество строк n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите строку {0}: ", i + 1);
                //вводим строку
                string str = Console.ReadLine();
                //Массив слов
                string[] arrStr = new string[(str.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)).Length];

                // Заполняем массив слов
                arrStr = str.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                // Инициализация массива
                array[i] = new int[arrStr.Length];

                // Если введенное слово можно конвертировать в число, оно его конвертирует, иначе ставит 0.
                for (int j = 0; j < arrStr.Length; j++)
                {
                    int num;
                    if (int.TryParse(arrStr[j], out num))
                    {
                        array[i][j] = num;
                    }
                    else array[i][j] = 0;
                }
            }

            Console.WriteLine("Введенные данные");
            for (int i = 0; i < n; i++)
            {
                Console.Write("#{0}: ", i + 1);
                foreach (var v in array[i]) Console.Write(v + " ");
                Console.WriteLine();
            }
            Console.WriteLine("  Min   Max   Sum");
            for (int i = 0; i < n; i++)
            {
                int min;
                int max;
                int sum;
                Min(ref array[i], out min);
                Max(in array[i], out max);
                Sum(ref array[i], out sum);
                Console.WriteLine("#{0}: {1}    {2}    {3}", i + 1, min, max, sum);
            }
        }
        static void Min(ref int[] array, out int min)
        {
            Array.Sort(array);
            min = array[0];
        }
        static void Max(in int[] array, out int max)
        {
            max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= max)
                    max = array[i];
            }
            //Array.Sort(array);
            //max = array[array.Length-1];
        }
        static void Sum(ref int[] array, out int sum)
        {
            sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
        }

    }
}
