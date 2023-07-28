using Domain.Entities;

namespace Service.DTOs.PersonDTOs
{
    public class PersonCreateDTO
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string? Linkedin { get; set; }
        public string? GitHub { get; set; }
    }
}
