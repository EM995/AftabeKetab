namespace AftabeKetab.DataModels
{
    public class EntityAuthor : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<EntityBook>? Books { get; set; }
    }
}
