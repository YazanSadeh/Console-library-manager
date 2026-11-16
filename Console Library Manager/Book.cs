namespace Console_Library_Manager
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public bool IsBorrowed { get; private set; }
        public Book(string title, string author, int year)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || year <= 0)
            {
                throw new ArgumentException("Invalid book information provided.");
            }
            Title = title;
            Author = author;
            Year = year;
            IsBorrowed = false;
        }
        public void Borrow()
        {
            if (IsBorrowed)
            {
                throw new InvalidOperationException($"The book '{Title}' is already borrowed.");
            }
            IsBorrowed = true;
        }
        public void Return()
        {
            if (!IsBorrowed)
            {
                throw new InvalidOperationException($"The book '{Title}' is not currently borrowed.");
            }
            IsBorrowed = false;
        }
    }
}
