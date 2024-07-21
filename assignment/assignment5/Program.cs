using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
            Console.ReadLine();
        }
    }

    public class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();                                             
            shelf[0] = new Books("Treasure Island", "Robert Louis Stevenson");
            shelf[1] = new Books("The Adventures of Tom Sawyer", "MarK Twain");
            shelf[2] = new Books("The Call of the Wild", "Jack London");
            shelf[3] = new Books("Jurassic Park", "Michael Crichton");
            shelf[4] = new Books("Around the World in Eighty days", "Jules Verne");

            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
    }
}