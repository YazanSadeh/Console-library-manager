public class Program
{
    public static void Main(string[] args)
    {
        List<string> books = new List<string>(){
    "Clean Code",
    "The Pragmatic Programmer",
    "Design Patterns",
    "Head First Design Patterns",
    "Code Complete",
    "Refactoring",
    "The Clean Coder",
    "Introduction to Algorithms",
    "C# in Depth",
    "Pro C# 10 with .NET 6",
    "ASP.NET Core in Action",
    "The C# Player's Guide",
    "Domain-Driven Design",
    "Cracking the Coding Interview",
    "You Don't Know JS"
};
        List<string> borrowedBooks = new List<string>();

        Console.WriteLine("Hello this is my small book shop please tell me how can I help you?");
        Console.WriteLine("Do you want to add a book, search for a book, borrow a book, or return a book?");
        Console.WriteLine("if you want to add a book please write 'add' and if you want to search for a book please write 'search' and if you want to borrow a book please write 'borrow' and if you want to return a book please write 'return' and then press enter.");

        while (true)
        {
            Console.WriteLine("Please enter your choice:");
            string input = Console.ReadLine();

            if (input == "add")
            {
                Console.WriteLine("Please enter the name of the book you want to add:");
                string bookToAdd = Console.ReadLine();

                // I do all of this because you told me to use linq and try and catch.
                try
                {
                    bool alreadyAdded = books.Where(b => b == bookToAdd).ToList().Count > 0;
                    if (!alreadyAdded)
                    {
                        books.Add(bookToAdd);
                    }
                    else
                    {
                        throw new Exception("This book is already in the library.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else if (input == "search")
            {
                Console.WriteLine("Please enter the name of the book you want to search:");
                string bookToSearch = Console.ReadLine();

                bool bookFound = books.Where(b => b == bookToSearch).ToList().Count > 0;
                if (bookFound)
                {
                    Console.WriteLine($"The book '{bookToSearch}' is available in the library.");
                }
                else
                {
                    Console.WriteLine($"The book '{bookToSearch}' is not available in the library.");
                }
            }
            else if (input == "borrow")
            {
                Console.WriteLine("Please enter the name of the book you want to borrow:");
                string bookToBorrow = Console.ReadLine();
                bool bookFound = books.Where(b => b == bookToBorrow).ToList().Count > 0;
                if (bookFound)
                {
                    try
                    {
                        bool alreadyBorrowed = borrowedBooks.Where(b => b == bookToBorrow).ToList().Count > 0;
                        if (alreadyBorrowed)
                        {
                            throw new Exception("This book is already borrowed.");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    borrowedBooks.Add(bookToBorrow);
                    Console.WriteLine($"You have borrowed the book '{bookToBorrow}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{bookToBorrow}' is not available in the library.");
                }
            }
            else if (input == "return")
            {
                Console.WriteLine("Please enter the name of the book you want to return:");
                string bookToReturn = Console.ReadLine();
                bool bookFound = borrowedBooks.Where(b => b == bookToReturn).ToList().Count > 0;
                if (bookFound)
                {
                    borrowedBooks.Remove(bookToReturn);
                    Console.WriteLine($"You have returned the book '{bookToReturn}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{bookToReturn}' was not borrowed from this library.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine("if you want to continue, please enter 'yes' and if not enter any character:");
            string continueInput = Console.ReadLine();
            if (continueInput != "yes")
            {
                break;
            }
        }

        Console.WriteLine("Thank you for using the library manager. Goodbye!");
    }
}