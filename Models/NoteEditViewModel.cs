using Note.Entities;

namespace Note.Models
{
    public class NoteEditViewModel : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    
}