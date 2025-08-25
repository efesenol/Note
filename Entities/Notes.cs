namespace Note.Entities
{
    public class Notes : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Users? Users { get; set; }
    }
}