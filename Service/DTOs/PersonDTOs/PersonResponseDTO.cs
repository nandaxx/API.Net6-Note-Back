using Domain.Entities;

namespace Service.DTOs.PersonDTOs
{
    public class PersonResponseDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Linkedin { get; set; }
        public string? GitHub { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
