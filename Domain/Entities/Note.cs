using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public Person Person { get; set; }
        public Note() { }
    }
}
