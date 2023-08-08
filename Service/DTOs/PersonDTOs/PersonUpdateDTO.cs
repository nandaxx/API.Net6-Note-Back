namespace Service.DTOs.PersonDTOs
{
    public class PersonUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PassWord { get; set; }
        public string? Email { get; set; }
        public string? Linkedin { get; set; }
        public string? GitHub { get; set; }
    }
}
