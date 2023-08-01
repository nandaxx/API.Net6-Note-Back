namespace Service.DTOs.NoteDTOs
{
    public class NoteUpdateDTO
    {
        public int? Id { get; set; }
        public string Menssage { get; set; }
        public string Title { get; set; }
        public string EmailPerson  { get; set; }
    }
}
