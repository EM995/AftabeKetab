using AftabeKetab.DataModels.Sales;

namespace AftabeKetab.DataModels
{
    public class OrderEntity : BaseEntity
    {
        public OrderStatus? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public DateTime? RequiredDate { get; set; } = DateTime.Now.AddDays(4);
        public DateTime? ShippedDate { get; set; } = DateTime.Now.AddDays(1);

        public UserEntity? Seller { get; set; }
        public Guid? SellerId { get; set; }

        public UserEntity? Buyer { get; set; }
        public Guid? BuyerId { get; set; }

        public OrderItemsEntity? Items { get; set; }
    }
}
