using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGenerator;

namespace LibraryAutomation
{
    class Book
    {
        static int id;

        public Book()
        {
            bookId = ++id;
        }

        public int bookId { get; set; }

        public string bookTitle { get; set; }
        public string ISBN { get; set; }
        public DateTime bookAvaliableState { get; set; }

        static Random rnd = new Random();
        static GenerateRandom generateRnd = new GenerateRandom();

        public static Book generateBook()
        {
            Book b = new Book();

            b.bookTitle = generateRnd.generateSentence(rnd.Next(1, 6));
            b.ISBN = generateRnd.generateNumber(10);
            b.bookAvaliableState = DateTime.Now;

            return b;
        }

        public static List<Book> generateBookList()
        {
            List<Book> bookList = new List<Book>();

            for (int i = 0; i < 5; i++)
            {
                bookList.Add(generateBook());
            }

            return bookList;
        }

        public string getInfoBook()
        {
            return $"Book id :\t{bookId}\nBook Title :\t{bookTitle}\nISBN :\t\t{ISBN}\nBook Avaliable :{bookAvaliableState} ";
        }
    }
}
