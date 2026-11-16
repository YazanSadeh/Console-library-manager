namespace Console_Library_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILibraryRepository repository = new LibraryRepository();
            while (true)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Show All Books");
                Console.WriteLine("4. Add Member");
                Console.WriteLine("5. Search Member");
                Console.WriteLine("6. Show All Members");
                Console.WriteLine("7. Borrow Book");
                Console.WriteLine("8. Return Book");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine()?.Trim();

                if (choice == null || choice == "0")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddBook(repository);
                            break;

                        case "2":
                            SearchBook(repository);
                            break;

                        case "3":
                            ShowAllBooks(repository);
                            break;

                        case "4":
                            AddMember(repository);
                            break;

                        case "5":
                            SearchMember(repository);
                            break;

                        case "6":
                            ShowAllMembers(repository);
                            break;

                        case "7":
                            BorrowBook(repository);
                            break;

                        case "8":
                            ReturnBook(repository);
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        private static string ReadText(string message)
        {
            Console.Write(message);

            string value = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Input cannot be empty.");

            return value;
        }
        private static int ReadNumber(string message)
        {
            string input = ReadText(message);

            int number;

            if (!int.TryParse(input, out number))
                throw new ArgumentException("Please enter a valid number.");

            return number;
        }
        private static void AddBook(ILibraryRepository repository)
        {
            string title = ReadText("Enter book title: ");
            string author = ReadText("Enter author: ");
            int year = ReadNumber("Enter publication year: ");

            if (repository.GetBook(title) != null)
                throw new InvalidOperationException("Book already exists.");

            Book book = new Book(title, author, year);

            repository.AddBook(book);

            Console.WriteLine("Book added successfully.");
        }
        private static void SearchBook(ILibraryRepository repository)
        {
            string title = ReadText("Enter book title: ");

            Book? book = repository.GetBook(title);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Year: {book.Year}");
            Console.WriteLine($"Borrowed: {book.IsBorrowed}");
        }
        private static void ShowAllBooks(ILibraryRepository repository)
        {
            var books = repository.GetAllBooks();

            if (!books.Any())
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(
                    $"{book.Title} - {book.Author} ({book.Year}) - " +
                    (book.IsBorrowed ? "Borrowed" : "Available")
                );
            }
        }
        private static void AddMember(ILibraryRepository repository)
        {
            string name = ReadText("Enter member name: ");
            int memberId = ReadNumber("Enter member ID: ");

            if (repository.GetMember(memberId) != null)
                throw new InvalidOperationException("Member already exists.");

            Member member = new Member(name, memberId);

            repository.AddMember(member);

            Console.WriteLine("Member added successfully.");
        }
        private static void SearchMember(ILibraryRepository repository)
        {
            int memberId = ReadNumber("Enter member ID: ");

            Member? member = repository.GetMember(memberId);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine($"ID: {member.MemberId}");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Borrowed books: {member.BorrowedBooks.Count}");
        }
        private static void ShowAllMembers(ILibraryRepository repository)
        {
            var members = repository.GetAllMembers();

            if (!members.Any())
            {
                Console.WriteLine("No members found.");
                return;
            }

            foreach (var member in members)
            {
                Console.WriteLine(
                    $"ID: {member.MemberId} | Name: {member.Name}"
                );
            }
        }
        private static void BorrowBook(ILibraryRepository repository)
        {
            int memberId = ReadNumber("Enter member ID: ");
            string title = ReadText("Enter book title: ");

            Member? member = repository.GetMember(memberId);
            Book? book = repository.GetBook(title);

            if (member == null)
                throw new InvalidOperationException("Member not found.");

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            member.BorrowBook(book);

            Console.WriteLine($"'{book.Title}' borrowed by {member.Name}.");
        }
        private static void ReturnBook(ILibraryRepository repository)
        {
            int memberId = ReadNumber("Enter member ID: ");
            string title = ReadText("Enter book title: ");

            Member? member = repository.GetMember(memberId);
            Book? book = repository.GetBook(title);

            if (member == null)
                throw new InvalidOperationException("Member not found.");

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            member.ReturnBook(book);

            Console.WriteLine($"'{book.Title}' returned successfully.");
        }
    }
}
