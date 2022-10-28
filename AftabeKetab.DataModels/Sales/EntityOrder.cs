using AftabeKetab.DataModels.Sales;

namespace AftabeKetab.DataModels
{
    public class EntityOrder : EntityBase
    {
        public OrderStatus? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public DateTime? RequiredDate { get; set; } = DateTime.Now.AddDays(4);
        public DateTime? ShippedDate { get; set; } = DateTime.Now.AddDays(1);

        public EntityUser? Seller { get; set; }
        public Guid? SellerId { get; set; }

        public EntityUser? Buyer { get; set; }
        public Guid? BuyerId { get; set; }

        public EntityOrderItems? Items { get; set; }
    }
}
