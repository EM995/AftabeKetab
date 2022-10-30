namespace AftabeKetab.DataModels
{
    public class UserEntity : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        public AddressEntity? ShippingAddress { get; set; }
        public Guid? AddressId { get; set; }

        public List<OrderEntity>? OrdersAsSeller { get; set; }

        public List<OrderEntity>? OrdersAsBuyer { get; set; }

        public List<BookEntity>? Books { get; set; }
    }
}