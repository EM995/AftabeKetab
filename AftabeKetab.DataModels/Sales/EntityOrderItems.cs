namespace AftabeKetab.DataModels.Sales
{
    public class EntityOrderItems : EntityBase
    {
        public int? Quantity { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? Discount { get; set; }

        public EntityOrder? Order { get; set; }

        public List<EntityBook>? Books { get; set; }
    }
}
