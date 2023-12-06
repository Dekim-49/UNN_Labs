using System;

    class BookGenre : Book
    {
        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public BookGenre(string name, string author, int price, string genre) : base(name, author, price)
        {
            Genre = genre;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Жанр: {0}", Genre);
        }

    }
