namespace Note.Entities
{
    public class Users : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();
    }
    
}