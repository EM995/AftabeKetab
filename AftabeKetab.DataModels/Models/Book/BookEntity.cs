using AftabeKetab.DataModels.Sales;

namespace AftabeKetab.DataModels
{
    public class BookEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DatePublished { get; set; }
        public decimal? Price { get; set; }
        public int? NumberOfPages { get; set; }

        public AuthorEntity? Author { get; set; }
        public Guid? AuthorId { get; set; }

        public List<CategoryEntity>? Categories { get; set; }

        public UserEntity? Owner { get; set; }
        public Guid? OwnerId { get; set; }

        public OrderItemsEntity? OrderItem { get; set; }
        public Guid? OrderItemId { get; set; }
    }
}
