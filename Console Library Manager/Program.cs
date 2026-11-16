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
            string input = (Console.ReadLine() ?? "").Trim().ToLower();

            if (input == "add")
            {
                Console.WriteLine("Please enter the name of the book you want to add:");
                string bookToAdd = (Console.ReadLine() ?? "").Trim().ToLower();
                // I do all of this because you told me to use linq and try and catch.
                try
                {
                    if (string.IsNullOrWhiteSpace(bookToAdd))
                    {
                        throw new Exception("Invalid book name. Please try again.");
                    }
                    bool alreadyAdded = books.Any(b => b.ToLower() == bookToAdd);
                    if (alreadyAdded) throw new Exception("This book is already in the library.");

                    books.Add(bookToAdd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else if (input == "search")
            {
                Console.WriteLine("Please enter the name of the book you want to search:");
                string bookToSearch = (Console.ReadLine() ?? "").Trim().ToLower();

                try
                {
                    if (string.IsNullOrWhiteSpace(bookToSearch))
                    {
                        throw new Exception("Invalid book name. Please try again.");
                    }
                    bool bookFound = books.Any(b => b.ToLower() == bookToSearch);
                    if (!bookFound) throw new Exception($"The book '{bookToSearch}' is not available in the library.");
                    Console.WriteLine($"The book '{bookToSearch}' is available in the library.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
            else if (input == "borrow")
            {
                Console.WriteLine("Please enter the name of the book you want to borrow:");
                string bookToBorrow = (Console.ReadLine() ?? "").Trim().ToLower();
                try
                {
                    if (string.IsNullOrWhiteSpace(bookToBorrow))
                    {
                        throw new Exception("Invalid book name. Please try again.");
                    }
                    bool bookFound = books.Any(b => b.ToLower() == bookToBorrow);
                    if (!bookFound) throw new Exception($"The book '{bookToBorrow}' is not available in the library.");
                    bool alreadyBorrowed = borrowedBooks.Any(b => b.ToLower() == bookToBorrow);
                    if (alreadyBorrowed) throw new Exception("This book is already borrowed.");
                    borrowedBooks.Add(bookToBorrow);
                    Console.WriteLine($"You have borrowed the book '{bookToBorrow}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else if (input == "return")
            {
                Console.WriteLine("Please enter the name of the book you want to return:");
                string bookToReturn = (Console.ReadLine() ?? "").Trim().ToLower();
                try
                {
                    if (string.IsNullOrWhiteSpace(bookToReturn))
                    {
                        throw new Exception("Invalid book name. Please try again.");
                    }
                    bool bookFound = borrowedBooks.Any(b => b.ToLower() == bookToReturn);
                    if (!bookFound) throw new Exception($"The book '{bookToReturn}' was not borrowed from this library.");

                    borrowedBooks.Remove(bookToReturn);
                    Console.WriteLine($"You have returned the book '{bookToReturn}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine("if you want to continue, please enter 'yes' and if not enter any character:");
            string continueInput = (Console.ReadLine() ?? "").Trim().ToLower();
            if (continueInput != "yes")
            {
                break;
            }
        }

        Console.WriteLine("Thank you for using the library manager. Goodbye!");
    }
}
