namespace AftabeKetab.DataModels
{
    public class AuthorEntity : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<BookEntity>? Books { get; set; }
    }
}
