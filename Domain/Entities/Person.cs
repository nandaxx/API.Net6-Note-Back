using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string? Linkedin { get; set; }
        public string? GitHub { get; set; }
        public ICollection<Note> Notes { get; set; }

        public Person() { }

        public override string? ToString()
        {
            return $"{Id}";
        }
    }
}
