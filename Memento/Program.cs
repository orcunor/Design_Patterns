using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = "12345", Title = "Sefiller", Author = "Victor Hugo" };
            book.ShowBook();


            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "56789";
            book.Title = "Kozmos";
            book.Author = "Carl Sagan";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        public DateTime _lastEdited;
        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get { return _author; }
            set 
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        
        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0} , {1} , {2} edited: {3}", Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
