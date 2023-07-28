using AutoMapper;
using Domain.Repositories;
using Service.DTOs.NoteDTOs;
using Service.DTOs.PersonDTOs;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class NoteService : INoteService

    {
        public readonly INoteRepository _repository;
        public readonly IMapper _mapper;

        public NoteService(INoteRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ExceptionManager<ICollection<NoteResponseDTO>>> FindAll()
        {
            var notes = await _repository.FindAll();
            return ExceptionManager.Ok(_mapper.Map<ICollection<NoteResponseDTO>>(notes));
        }

        public async Task<ExceptionManager<NoteResponseDTO>> FindById(int id)
        {
            if ( id <= 0)
            {
                return ExceptionManager.NotAcceptable<NoteResponseDTO>();
            }

            var notes = await _repository.FindById(id);

            if (notes == null)
            {
                return ExceptionManager.NotFound<NoteResponseDTO>();
            }

            return ExceptionManager.Ok<NoteResponseDTO>(_mapper.Map<NoteResponseDTO>(notes));
        }

        public async Task<ExceptionManager<NoteResponseDTO>> Create(NoteCreateDTO person)
        {
            throw new NotImplementedException();
        }

        public async Task<ExceptionManager<NoteResponseDTO>> Update(NoteUpdateDTO person)
        {
            throw new NotImplementedException();
        }
        public async Task<ExceptionManager> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
