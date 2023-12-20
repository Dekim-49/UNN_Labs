using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homewirk6
{
    class Homewirk6
    {
        static void Main(string[] args)
        {
            //Создаем экземпляр класса TaskManager
            TaskManager taskManager = new TaskManager();

            //Создаём несколько задач
            Task[] tasks = new Task[5];
            tasks[0] = new Task("Полить цветы", "Набрать воды и полить глдиолус");
            tasks[1] = new Task("Купить хлеба", "Цельноцернового или ржаного");
            tasks[2] = new Task("Купить краски", "Акрил, черный, ерихкраузер");
            tasks[3] = new Task("Обед", "Суп, салатик и чаёк");
            tasks[4] = new Task("Сдать зачот", "JUST DO IT");
            
            //Проверка для себя
            Console.WriteLine("Статус задач");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Задание №{0} - {1} | Статус: {2}", i+1, tasks[i].Name, tasks[i].Status);
            }
            Console.WriteLine("==========================");

            
            // Добавляем в экземпляр делегата сообщение
            taskManager.statusChanged += Message.TaskCompletedNotification;

            //Меняем статус заданий и выводиим сообщение на экран
            for (int i = 0; i < 5; i++)
            {
                taskManager.CompleteTask(tasks[i]);
            }

            Console.WriteLine("==========================");

            //Проверка для себя
            Console.WriteLine("Статус задач");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Задание №{0} - {1} | Статус: {2}", i + 1, tasks[i].Name, tasks[i].Status);
            }

            Console.ReadLine();
        }
    }

    public class Task
    {
        //Имя задачи
        public string Name { get; set; }
        //Описание задачи
        public string About { get; set; }
        //Статус задачи
        public bool Status { get; set; }


        // Конструктор
        public Task(string name, string about)
        {
            Name = name;
            About = about;
            Status = false;
        } 
    }

    public class TaskManager
    {
        //Создаем делегат и передаём ему в качестве аргумента какую-то задачу
        public delegate void DStatusChanged(Task task);
        //Создаём экземпляр делегата
        public DStatusChanged statusChanged;


        // Функция, менющая статус задачи и вызывающая функция с вызовом метода из делегата
        public void CompleteTask(Task task)
        {
            task.Status = true;
            StatusChanged(task);
        }

        // Функция которая вызывает метод из делегата.
        public void StatusChanged(Task task)
        {
            statusChanged?.Invoke(task);
        }
    }

    public class Message
    {
        // Та самая функция которую мы передадим в наш делегат в самой программе.
        // Она будет выдавать нам сообщение
        //Static так как мы обращаемся не к конкретному объекту класса, а ко всему классу
        public static void TaskCompletedNotification(Task task)
        {
            Console.WriteLine("Задача \"{0}\" выполнена", task.Name);
        }
    }

   
 
}
