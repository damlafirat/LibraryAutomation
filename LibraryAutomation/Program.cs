using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation
{
    class Program
    {
        static List<Book> books = Book.generateBookList();
        static List<Member> members = Member.generateMemberList();

        static void Main(string[] args)
        {
            menu();
        }

        private static void menu()
        {
            Console.WriteLine("1.\tView details of Books");
            Console.WriteLine("2.\tView details of Members");
            Console.WriteLine("3.\tBorrow");
            Console.WriteLine("4.\tReturn");
            Console.WriteLine("5.\tExit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    listBook();
                    break;

                case "2":
                    listMember();
                    break;

                case "3":
                    borrowBook();
                    break;

                case "4":
                    returnBook();
                    break;

                case "5":
                    exit();
                    break;

                default:
                    invalidChoice();
                    break;
            }
        }

        private static void invalidChoice()
        {
            Console.Clear();

            Console.WriteLine("Wrong choice");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void exit()
        {
            Environment.Exit(0);
        }

        private static void returnBook()
        {
            Console.Clear();

            Console.Write("Enter member id : ");
            string mId =Console.ReadLine();

            if (checkValue(mId))
            {
                var memberState = members.Where(p => p.memberId == int.Parse(mId)).FirstOrDefault();
                if (memberState != null)
                {
                    if (memberState.memberBook != null)
                    {
                        var bookState = books.Where(p => p.bookId == (from m in members where m.memberId == int.Parse(mId) select m.memberBook.bookId).FirstOrDefault()).FirstOrDefault();

                        memberState.memberBook = null;
                        bookState.bookAvaliableState = DateTime.Now;

                        Console.WriteLine("Transaction successful");
                    }

                    else
                        Console.WriteLine("Member have any books");
                }

                else
                    Console.WriteLine("İnvalid member");
            }

            else
                Console.WriteLine("İnvalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void borrowBook()
        {
            Console.Clear();

            Console.Write("Enter Member id : ");
            string mId = Console.ReadLine();

            Console.Write("Enter Book id : ");
            string bId = Console.ReadLine();

            if (checkValue(mId) || checkValue(bId))
            {
                var memberState = members.Where(p => p.memberId == int.Parse(mId)).FirstOrDefault();
                var bookState = books.Where(p => p.bookId == int.Parse(bId)).FirstOrDefault();

                if (memberState != null && bookState != null)
                {
                    bookState.bookAvaliableState = DateTime.Now.AddDays(14);
                    memberState.memberBook = bookState;

                    Console.WriteLine("Transaction successful");
                }

                else
                    Console.WriteLine("Invalid member id or book id");
            }
                
            else
                Console.WriteLine("İnvalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static bool checkValue(string s)
        {
            int result;

            if (int.TryParse(s, out result))
                return true;

            else
                return false;
        }

        private static void listMember()
        {
            Console.Clear();

            foreach (var item in members)
            {
                Console.WriteLine(item.getInfoMember());
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void listBook()
        {
            Console.Clear();

            foreach (var item in books)
            {
                Console.WriteLine(item.getInfoBook());
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }
    }
}
