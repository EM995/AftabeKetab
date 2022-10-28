namespace AftabeKetab.DataModels
{
    public class EntityCategory : EntityBase
    {
        public string? Name { get; set; }

        public List<EntityBook>? Books { get; set; }
    }
}
