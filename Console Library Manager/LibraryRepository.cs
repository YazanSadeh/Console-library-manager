namespace Console_Library_Manager
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly List<Book> _books = new();
        private readonly List<Member> _members = new();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void AddMember(Member member)
        {
            _members.Add(member);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public List<Member> GetAllMembers()
        {
            return _members;
        }
        public Book? GetBook(string title)
        {
            return _books.FirstOrDefault(b => b.Title == title);
        }

        public Member? GetMember(int memberId)
        {
            return _members.FirstOrDefault(m => m.MemberId == memberId);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
