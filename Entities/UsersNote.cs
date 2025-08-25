namespace Note.Entities
{
    public class UserNote : BaseEntity
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public Notes? Notes { get; set; }
        public Users? Users { get; set; }
    }
}