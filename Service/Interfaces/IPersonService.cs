using Service.DTOs.PersonDTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IPersonService
    {

        Task<ExceptionManager<ICollection<PersonResponseDTO>>> FindAll();
    }
}
