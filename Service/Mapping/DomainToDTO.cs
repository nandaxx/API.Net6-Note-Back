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
            CreateMap<Note, NoteResponseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.EmailPerson, opt => opt.MapFrom(src => src.Person.Email));
            CreateMap<Note, NoteUpdateDTO>();


        }
    }
}
