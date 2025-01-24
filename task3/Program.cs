using System.Reflection;

namespace task3
{

    class Book
    {
        string title;
        string author;
        string isbn;
        bool availability; 


        public Book(string title , string author , string isbn )
        {
            this.title = title;
            this.author = author; 
            this.isbn = isbn;
            availability = true; 
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string title)
        {
            this.title = title; 
        }

        public string GetAuthor()
        { 
            return author;
        }
        public void SetAuthor(string author)
        {
            this.author = author; 
        }



        public string GetIsbn() 
        {
            return isbn;
        }

        public void SetIsbn(string isbn)
        { 
            this.isbn = isbn;
        }


        public bool GetAvailability()
        {
            return availability;  
        }

        public void SetAvailability(bool availability)
        { 
            this.availability =availability;    
        }


    }

    class Library
    { 
    
        public List<Book> books = new List<Book>();


        public void AddBook(Book book)
        { 
            books.Add(book);
        }

        public int SearchBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (title == books[i].GetTitle())
                {
                    return i;
                }
            }

            return -1; 
            
        }

        public bool BorrowBook(string title)
        {
            int bookPosition = SearchBook(title);
            if (bookPosition != -1)
            {
                if (books[bookPosition].GetAvailability())
                {
                    books[bookPosition].SetAvailability(false);
                    return true;
                }
            }

            return false;
        }

        public bool ReturnBook(string title)
        {
            int bookPosition = SearchBook(title);
            if (bookPosition != -1)
            {
                if (books[bookPosition].GetAvailability() == false)
                {
                    books[bookPosition].SetAvailability(true); 
                    return true;
                }
            }

            return false;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library
            
            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

        }
    }
}
