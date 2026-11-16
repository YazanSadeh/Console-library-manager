namespace Console_Library_Manager
{
    public interface ILibraryRepository
    {
        List<Book> GetAllBooks();
        Book? GetBook(string title);
        void AddBook(Book book);
        void RemoveBook(Book book);
        void AddMember(Member member);
        List<Member> GetAllMembers();
        Member? GetMember(int memberId);
    }
}
