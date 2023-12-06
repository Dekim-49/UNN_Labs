using System;

    public class Book
    {
        private string name;
        private string author;
        private int price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Book(string name, string author, int price)
        {
            Name = name;
            Author = author;
            Price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine("Название: {0}", Name);
            Console.WriteLine("Автор: {0}", Author);
            Console.WriteLine("Цена: {0}", Price);
        }
    }

