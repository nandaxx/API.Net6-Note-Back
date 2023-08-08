using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOs.NoteDTOs;
using Service.DTOs.PersonDTOs;
using Service.Exceptions;
using Service.Interfaces;
using System;

namespace Service.Services
{
    public class NoteService : INoteService

    {
        public readonly IPersonRepository _person;
        public readonly INoteRepository _repository;
        public readonly IMapper _mapper;

        public NoteService(IPersonRepository person, INoteRepository repository, IMapper mapper)
        {
            _person = person;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ExceptionManager<ICollection<NoteResponseDTO>>> FindAll()
        {
            var notes = await _repository.FindAll();
            return ExceptionManager.Ok(_mapper.Map<ICollection<NoteResponseDTO>>(notes));
        }

        public async Task<ExceptionManager<NoteResponseDTO>> FindById(int id)
        {
            if (id <= 0)
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

        public async Task<ExceptionManager<NoteResponseDTO>> Create(NoteCreateDTO note)
        {
            if (note.EmailPerson == null) return ExceptionManager.BadRequest<NoteResponseDTO>();
            var verify = await _person.FindByEmail(note.EmailPerson);
            if (verify == null) return ExceptionManager.BadRequest<NoteResponseDTO>();
            var newNote = _mapper.Map<Note>(note);
            newNote.Person = verify;
            var response = await _repository.Create(newNote);
            return ExceptionManager.Created<NoteResponseDTO>(_mapper.Map<NoteResponseDTO>(response));
        }

        public async Task<ExceptionManager<NoteResponseDTO>> Update(NoteUpdateDTO note)
        {
            if (note.EmailPerson == null) return ExceptionManager.BadRequest<NoteResponseDTO>();
            var verify = await _person.FindById((int)note.Id);
            if (verify == null) return ExceptionManager.NotFound<NoteResponseDTO>();
            var newNote = await _repository.FindById((int)note.Id);
            if (newNote == null) return ExceptionManager.NotFound<NoteResponseDTO>();
            newNote = _mapper.Map<NoteUpdateDTO, Note>(note, newNote);
            var response = await _repository.Update(newNote);
            return ExceptionManager.Ok<NoteResponseDTO>(_mapper.Map<NoteResponseDTO>(response));
        }
        public async Task<ExceptionManager> Delete(int id)
        {
            if (id <= 0)
            {
                return ExceptionManager.NotAcceptable<NoteResponseDTO>();
            }

            var note = await _repository.FindById(id);

            if (note == null)
            {
                return ExceptionManager.NotFound<NoteResponseDTO>();
            }

            var response = _repository.Delete(id);
            return ExceptionManager.Ok(response);
        }
    }

}
