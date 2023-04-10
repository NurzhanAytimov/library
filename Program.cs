using System;

namespace LibraryBooks
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("[1] Add a book");
            Console.WriteLine("[2] Remove a book");
            Console.WriteLine("[3] Get a list all of books");
            Console.WriteLine("[4] Enter the name of the book you want to find");
            Console.WriteLine("[5] Exit");
            int result = int.Parse(Console.ReadLine());

            using (var db = new BooksContext()) 
            {
               
                if(result == 1)   //добавить книгу
                {
                    Console.WriteLine("Enter title book: ");
                    string title = Console.ReadLine();
                    
                    Console.WriteLine("Enter author book: ");
                    string author = Console.ReadLine();

                    db.books.Add(new Books { Name = title, Author = author });
                    db.SaveChanges();
                    Console.WriteLine("Book added successfully!");
                }
                else if(result == 2) // удалить книгу
                {
                    Console.WriteLine("Enter name book you want to delete");
                    string name = Console.ReadLine();

                    var delete = db.books.FirstOrDefault(d => d.Name == name);
                    if(delete != null)
                    {
                        db.books.Remove(delete);
                        db.SaveChanges();
                        Console.WriteLine("Book remove!");
                    }
                }

                 else if(result == 3) // получить полный список книг
                {
                    var books = db.books.ToList();

                    foreach(var book in books)
                    {
                        Console.WriteLine($"Book name: {book.Name}, Book author: {book.Author}");
                    }
                }

                else if(result == 4) //поиск книги по названию
                {
                    Console.WriteLine("Enter book title you want find");
                    string name = Console.ReadLine();
                    var book = db.books.Find(name);

                    if(book == null) //если книга отсутсвует то выбрасываем исключение
                    {
                        throw new InvalidCastException("Book not find!");
                    }
                    else
                    {
                        Console.WriteLine($"book which you find {book}");
                    }
                }

                else if(result == 5) 
                {
                    throw new InvalidCastException("Goodbye!");
                }


              
            }
        }
    }
}
