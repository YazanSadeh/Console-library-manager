namespace Console_Library_Manager
{
    public class Member
    {
        public string Name { get; private set; }
        public int MemberId { get; private set; }
        public List<Book> BorrowedBooks { get; private set; }

        public Member(string name, int memberId)
        {
            if (string.IsNullOrWhiteSpace(name) || memberId <= 0)
            {
                throw new ArgumentException("Invalid member information provided.");
            }
            Name = name;
            MemberId = memberId;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            book.Borrow();
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            if (!BorrowedBooks.Contains(book))
            {
                throw new InvalidOperationException($"The book '{book.Title}' is not currently borrowed.");
            }
            book.Return();
            BorrowedBooks.Remove(book);
        }
    }
}
