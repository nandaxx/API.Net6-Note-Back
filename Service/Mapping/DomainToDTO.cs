using AutoMapper;
using Domain.Entities;
using Service.DTOs.NoteDTOs;
using Service.DTOs.PersonDTOs;

namespace Service.Mapping
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Person, PersonCreateDTO>();
            CreateMap<Person, PersonResponseDTO>();
            CreateMap<Person, PersonUpdateDTO>();

            CreateMap<Note, NoteCreateDTO>();
            CreateMap<Note, NoteResponseDTO>();
            CreateMap<Note, NoteUpdateDTO>();


        }
    }
}
