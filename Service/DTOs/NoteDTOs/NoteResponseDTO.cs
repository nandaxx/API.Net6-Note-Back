using Domain.Entities;

namespace Service.DTOs.NoteDTOs
{
    public class NoteResponseDTO
    {
        public int? Id { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string EmailPerson { get; set; }

    }
}
