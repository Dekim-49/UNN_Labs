using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1
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
            Console.WriteLine("5 - Task5");

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if ((choice > 5 || choice < 1))
                {
                    Console.WriteLine("Неверный ввод!");
                }

            } while ((choice > 5 || choice < 1));
            switch (choice)
            {
                case 1:
                    {
                        Task_1();
                        goto menu;
                    }
                case 2:
                    {
                        Task_2();
                        goto menu;
                    }
                case 3:
                    {
                        Task_3();
                        goto menu;
                    }
                case 4:
                    {
                        Task_4();
                        goto menu;
                    }
                case 5:
                    {
                        Task_5();
                        goto menu;
                    }
            }
            Console.ReadLine();
        }

        static void Task_1()
        {
            int size = 100; //Размер стэка по условию задачи
            Stack stack = new Stack(size);
            string[] arrayCommand = { "push 3",
                                      "push 14",
                                      "size",
                                      "clear",
                                      "push 1",
                                      "back",
                                      "push 2",
                                      "back",
                                      "pop",
                                      "size",
                                      "pop",
                                      "size",
                                      "exit"};
            int i = 0;
            while (i != arrayCommand.Length)
            {
                Console.Write(">> |");
                string[] vs = arrayCommand[i].Split(' ');
                string comand = vs[0];

                //string vs = Console.ReadLine(); //Если с клавы
                //string[] h = vs.Split(' ');
                //string comand = h[0];
                switch (comand)
                {
                    case "push":
                        {
                            int x;
                            int.TryParse(vs[1], out x);
                            //int.TryParse(h[1], out x); //Если с клавы
                            stack.Push(x, 0);
                            break;
                        }
                    case "pop":
                        {
                            stack.Pop(0);
                            break;
                        }
                    case "back":
                        {
                            stack.Back(0);
                            break;
                        }
                    case "size":
                        {
                            stack.Size(0);
                            break;
                        }
                    case "clear":
                        {
                            stack.Clear();
                            break;
                        }
                    case "exit":
                        {
                            stack.Exit();
                            break;
                        }
                }
                //stack.Print();
                i++;
            }
        }
        static void Task_2()
        {
            int size = 5; //Размер  по условию задачи

            //Queue queue = new Queue(size); //Реализация через массив
            Queue_2<int> queue = new Queue_2<int>();  //Реализация человеческая

            string[] arrayCommand_1 = { "push 1", "front", "exit" };
            //string[] arrayCommand_1 = { "size", "push 1", "size", "push 2", "size", "push 3", "size", "pop", "size", "exit" };

            int i = 0;
            while (i != arrayCommand_1.Length)
            {
                Console.Write(">> |");
                string[] vs = arrayCommand_1[i].Split(' ');
                string comand = vs[0];

                //string vs = Console.ReadLine(); //Если с клавы
                //string[] h = vs.Split(' ');
                //string comand = h[0];
                switch (comand)
                {
                    case "push":
                        {
                            int x;
                            int.TryParse(vs[1], out x);
                            //int.TryParse(h[1], out x); //Если с клавы
                            queue.Push(x);
                            break;
                        }
                    case "pop":
                        {
                            if (queue.Size(1) == 0)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            queue.Pop();
                            break;
                        }
                    case "front":
                        {
                            if (queue.Size(1) == 0)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            queue.Front();
                            break;
                        }
                    case "size":
                        {
                            queue.Size(0);
                            break;
                        }
                    case "clear":
                        {
                            queue.Clear();
                            break;
                        }
                    case "exit":
                        {
                            queue.Exit();
                            break;
                        }
                }
                //queue.Print();
                //Console.WriteLine();
                i++;
            }

        }
        static void Task_3()
        {
            Console.Write("Выражение (Пишите с пробелами): ");
            string equation_full = "( 2 + 1 ) - ( 4 + 9 ) * 10 + ( ( ( ( 4 + 3 ) + 2 ) * 2 ) + 3 )";
            //string equation_full = Console.ReadLine();

            string[] equation = equation_full.Split(' ');

            int indexRightBracket = -1; //Индекс первой правой скобки

            Stack stack = new Stack(equation.Length);


            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == "(")
                {
                    //Console.WriteLine("Bracket (");
                    stack.Push(1, 1);
                }
                if (equation[i] == ")")
                {
                    //Console.WriteLine("Bracket )");
                    if (stack.Size(1) > 0)
                    {
                        stack.Pop(1);
                    }
                    else
                    {
                        indexRightBracket = i;
                    }
                }
            }
            if (indexRightBracket == -1 && stack.Size(1) == 0)
            {
                Console.WriteLine("Да, корректно");
            }
            else
            {
                if (indexRightBracket != -1)
                {
                    Console.Write("Нет, не корректно\nПозиция правой лишней скобки: {0}", indexRightBracket);
                }
                if (stack.Size(1) != 0)
                {
                    Console.Write("Нет, не корректно\nКоличество лишних правых скобок: {0}", stack.Size(0));
                }
            }
        }
        static void Task_4()
        {
            DoubleQueue<int> queue = new DoubleQueue<int>();
            //Добавление элементов в список
            queue.AddFirst(1);
            queue.AddFirst(2);
            queue.AddFirst(3);
            queue.AddFirst(4);
            queue.AddFirst(5);

            queue.AddLast(6);
            queue.AddLast(4);
            queue.AddLast(7);
            queue.AddLast(8);
            queue.AddLast(9);
            queue.Print();

            Console.Write("Операция RemoveFirst: ");
            queue.RemoveFirst();
            queue.Print();

            Console.Write("Операция RemoveLast: ");
            queue.RemoveLast();
            queue.Print();

            Console.Write("Операция Find(4): ");
            queue.Find(4);
            Console.Write("\n");
            //queue.Print();

            Console.Write("Операция Remove(4): ");
            queue.Remove(4);
            queue.Print();
        }

        static void Task_5()
        {
            Console.WriteLine("Введите количество элементов N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("#{0} = ", i + 1);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (Math.Abs(array[i + 1] - array[i]) == 1)
                {
                    Console.WriteLine("Да, имеются");
                    break;
                }

                if (i == n - 2) Console.WriteLine("Нет, не имеются");
            }
        }
    }



    class Stack
    {
        //Гарантируется, что 
        // кол-во эл-в в стеке в любой момент не превосходит 100
        // все команды pop и back корректны
        int[] stack; //Массив элементов
        int top = 0; //количество элементов в стаке 
        public Stack(int size) //Конструктор
        {
            stack = new int[size];
        }
        public void Push(int n, int x) //Добавить число
        {
            if (x == 1)
            {
                stack[top] = n;
                top++;
            }
            else
            {
                stack[top] = n;
                top++;
                Console.WriteLine("OK");
            }

        }
        public void Pop(int x) //Удалить последний эл-т
        {
            if (x == 1)
            {
                stack[top - 1] = 0;
                top--;
            }
            else
            {
                stack[top - 1] = 0;
                top--;
                Console.WriteLine(stack[top]);
            }

        }
        public int Size(int x) //Размер стека
        {
            if (x == 1)
            {
                return top;
            }
            Console.WriteLine(top);
            return top;
        }
        public void Clear() //Очистить стэк
        {
            Array.Clear(stack, 0, stack.Length);

            //for (int i = 0; i < top; i++) stack[i] = 0; //Если нельзя использоваться array
            top = 0;
            Console.WriteLine("OK");

        }
        public int Back(int x) //Верхний эл-т
        {
            if (x == 1)
            {
                return stack[top - 1];
            }
            Console.WriteLine(stack[top - 1]);
            return stack[top - 1];
        }
        public void Exit() //Выход
        {
            Console.WriteLine("Bye");
            Console.ReadLine();
            Environment.Exit(0);
        }
        //public void Print()
        //{
        //    foreach(var x in stack)
        //    {
        //        Console.Write(x + " ");
        //    }
        //}
    }
    class Queue
    {
        int[] queue;
        int count = 0;
        public Queue(int size)
        {
            queue = new int[size];
        }
        public void Push(int x)
        {
            queue[count] = x;
            count++;
            Console.WriteLine("OK");
        }
        public void Pop() //Удалить последний эл-т
        {
            Console.WriteLine(queue[0]);
            for (int i = 0; i < count - 1; i++)
            {
                queue[i] = queue[i + 1];
            }
            queue[count - 1] = 0;
            count--;
        }
        public void Front()
        {
            Console.WriteLine(queue[0]);
        }
        public int Size(int x) //Размер стека
        {
            //1 - Вызывается в качестве проверки на пустоту
            //не 1 - вызывается чтобы выдал размер
            if (x == 1)
            {
                return count;
            }
            Console.WriteLine(count);
            return count;
        }
        public void Clear() //Очистить стэк
        {
            Array.Clear(queue, 0, queue.Length);
            //for (int i = 0; i < count; i++) queue[i] = 0; //Если нельзя использоваться array
            count = 0;
            Console.WriteLine("OK");
        }
        public void Exit() //Выход
        {
            Console.WriteLine("Bye");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void Print()
        {
            foreach (var x in queue)
            {
                Console.Write(x + " ");
            }
        }

    }
    class Queue_2<T>
    {
        //Используется класс Node, но только поле next
        Node<T> first; //Начало списка
        Node<T> next; //конец списка

        int count; //количество

        public void Push(T n)
        {
            Node<T> node = new Node<T>(n);
            if (first == null) first = node; //если нет головы, делаем голову, иначе добавляем далее
            else
            {
                next.Next = node;
            }
            next = node; //теперь нод - это последний элемент
            count++;
            Console.WriteLine("OK");
        }
        public void Pop()
        {
            Console.WriteLine(first.Data);
            first = first.Next;
            if (first == null) next = null;
            count--;
        }
        public void Front() //вывод первого эл-а
        {
            Console.WriteLine(first.Data);
        }
        public int Size(int x)
        {
            //1 - Вызывается в качестве проверки на пустоту
            //не 1 - вызывается чтобы выдал размер
            if (x == 1)
            {
                return count;
            }
            Console.WriteLine(count);
            return count;
        }
        public void Clear()
        {
            first = null;
            next = null;
            count = 0;
            Console.WriteLine("OK");
        }
        public void Exit() //Выход
        {
            Console.WriteLine("Bye");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public void Print()
        {
            Node<T> node = first;
            for (int i = 0; i < count; i++)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

    }

    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }

    class DoubleQueue<T>
    {
        Node<T> previous; //первый элемент
        Node<T> next; //последний
        int count;

        public void Find(T data)
        {
            //Ставим указатель на начало списка
            Node<T> node = previous;
            for (int i = 0; i < count; i++)
            {
                //Пока не нашли - идём дальше, иначе печатаем индекс
                if (node.Data.Equals(data))
                {
                    Console.Write(i + " ");
                }
                node = node.Next;
            }
        }
        public void AddLast(T data)
        {
            //Создаем новый Нод
            Node<T> node = new Node<T>(data);
            if (previous == null) previous = node; //Если нет головы списка - ставим Нод в голову
            //иначе добавляем элемент в хвост, связывая его с предшествующим
            else
            {
                next.Next = node;
                node.Previous = next;
            }
            next = node;

            count++;
        }
        public void AddFirst(T data)
        {
            //создаем новый нод и голову списка
            Node<T> newhead = new Node<T>(data);
            Node<T> node = previous;
            //соединяем новую голову и старую
            newhead.Next = node;
            previous = newhead;
            if (count == 0) next = previous;
            else node.Previous = newhead;
            count++;
        }
        public void RemoveFirst()
        {
            if (count > 1)
            {
                //перемещаемся к следующему элементу и рвём связь с головой
                previous = previous.Next;
                previous.Previous = null;
                count--;
            }
            else
            {
                previous = null;
            }
        }
        public void RemoveLast()
        {
            if (count > 1)
            {
                next = next.Previous;
                next.Next = null;
                count--;
            }
            else
            {
                next = null;
            }

        }


        public void Remove(T data)
        {
            Node<T> node = previous;
            int repeat = 0; //Количество вхождений элемента data в список
            for (int i = 0; i < count; i++)
            {
                //Пока не нашли - идём дальше
                if (node.Data.Equals(data))
                {
                    repeat++;
                }
                node = node.Next;
            }

            //Удаляет ВСЕ вхождения элемента в список
            for (int i = 0; i < repeat; i++)
            {
                node = previous;
                //Ищем нужный элемент
                while (node != null)
                {
                    if (node.Data.Equals(data))
                    {
                        break;
                    }
                    //переходим к следующему
                    node = node.Next;
                }
                if (node != null)
                {
                    if (node.Next != null) //Если после эл-а есть ещё эл-ы
                    {
                        //соединяю левый эл-т от Нода с правым эл-ом от нода
                        node.Next.Previous = node.Previous;
                    }
                    else
                    {
                        next = node.Previous;
                    }
                    // если это не первый элемент
                    if (node.Previous != null)
                    {
                        node.Previous.Next = node.Next;
                    }
                    else
                    {
                        previous = node.Next;
                    }
                    count--;
                }
            }


        }
        public void Print()
        {
            Node<T> node = previous;
            for (int i = 0; i < count; i++)
            {
                Console.Write(node.Data + " ");
                node = node.Next;

            }
            Console.WriteLine();
        }
    }
}
