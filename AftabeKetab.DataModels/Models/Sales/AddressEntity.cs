namespace AftabeKetab.DataModels
{
    public class AddressEntity : BaseEntity
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public List<UserEntity>? Users { get; set; }
    }
}