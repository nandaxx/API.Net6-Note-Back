using Service.DTOs.NoteDTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface INoteService
    {
        Task<ExceptionManager<ICollection<NoteResponseDTO>>> FindAll();
        Task<ExceptionManager<NoteResponseDTO>> FindById(int id);
        Task<ExceptionManager<NoteResponseDTO>> Create(NoteCreateDTO person);
        Task<ExceptionManager<NoteResponseDTO>> Update(NoteUpdateDTO person);
        Task<ExceptionManager> Delete(int id);
    }
}
