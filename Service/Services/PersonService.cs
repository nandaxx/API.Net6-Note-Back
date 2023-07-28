using AutoMapper;
using Domain.Repositories;
using Service.DTOs.PersonDTOs;
using Service.Exceptions;
using Service.Interfaces;
using System;

namespace Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ExceptionManager<ICollection<PersonResponseDTO>>> FindAll()
        {
            var people = await _repository.FindAll();
            return ExceptionManager.Ok(_mapper.Map<ICollection<PersonResponseDTO>>(people));
        }
        public async Task<ExceptionManager<PersonResponseDTO>> FindById(int id)
        {
            if (id <= 0)
            {
                return ExceptionManager.NotAcceptable<PersonResponseDTO>();
            }

            var person = await _repository.FindById(id);

            if (person == null)
            {
                return ExceptionManager.NotFound<PersonResponseDTO>();
            }

            return ExceptionManager.Ok<PersonResponseDTO>(_mapper.Map<PersonResponseDTO>(person));

        }
        public async Task<ExceptionManager<PersonResponseDTO>> Create(PersonCreateDTO person)
        {
            throw new NotImplementedException();
        }
        public async Task<ExceptionManager<PersonResponseDTO>> Update(PersonUpdateDTO person)
        {
            throw new NotImplementedException();
        }
        public async Task<ExceptionManager> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
