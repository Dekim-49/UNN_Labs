using System;

    sealed class BookGenrePubl : BookGenre
    {
        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public BookGenrePubl(string name, string author, int price, string genre, string publisher) : base(name, author, price, genre)
        {
            Publisher = publisher;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Издатель: {0}", Publisher);
        }

    }

