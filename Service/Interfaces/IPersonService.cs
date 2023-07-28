using Service.DTOs.PersonDTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IPersonService
    {

        Task<ExceptionManager<ICollection<PersonResponseDTO>>> FindAll();
        Task<ExceptionManager<PersonResponseDTO>> FindById(int id);
        Task<ExceptionManager<PersonResponseDTO>> Create(PersonCreateDTO person);
        Task<ExceptionManager<PersonResponseDTO>> Update(PersonUpdateDTO person);
        Task<ExceptionManager> Delete(int id);
    }
}
