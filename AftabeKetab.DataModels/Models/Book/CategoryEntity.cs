namespace AftabeKetab.DataModels
{
    public class CategoryEntity : BaseEntity
    {
        public string? Name { get; set; }

        public List<BookEntity>? Books { get; set; }
    }
}
