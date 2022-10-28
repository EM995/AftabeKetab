namespace AftabeKetab.DataModels
{
    public class EntityAddress : EntityBase
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public List<EntityUser>? Users { get; set; }
    }
}