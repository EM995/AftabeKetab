namespace AftabeKetab.DataModels
{
    public class EntityUser : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        public EntityAddress? ShippingAddress { get; set; }
        public Guid? AddressId { get; set; }

        public List<EntityOrder>? OrdersAsSeller { get; set; }

        public List<EntityOrder>? OrdersAsBuyer { get; set; }

        public List<EntityBook>? Books { get; set; }
    }
}