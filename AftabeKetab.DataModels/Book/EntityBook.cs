using AftabeKetab.DataModels.Sales;

namespace AftabeKetab.DataModels
{
    public class EntityBook : EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DatePublished { get; set; }
        public decimal? Price { get; set; }
        public int? NumberOfPages { get; set; }

        public EntityAuthor? Author { get; set; }
        public Guid? AuthorId { get; set; }

        public List<EntityCategory>? Categories { get; set; }

        public EntityUser? Owner { get; set; }
        public Guid? OwnerId { get; set; }

        public EntityOrderItems? OrderItem { get; set; }
        public Guid? OrderItemId { get; set; }
    }
}
