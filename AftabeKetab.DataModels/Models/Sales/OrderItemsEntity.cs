namespace AftabeKetab.DataModels.Sales
{
    public class OrderItemsEntity : BaseEntity
    {
        public int? Quantity { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? Discount { get; set; }

        public OrderEntity? Order { get; set; }

        public List<BookEntity>? Books { get; set; }
    }
}
