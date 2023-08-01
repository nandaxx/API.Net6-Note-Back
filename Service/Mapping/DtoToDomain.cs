using AutoMapper;
using Domain.Entities;
using Service.DTOs.NoteDTOs;
using Service.DTOs.PersonDTOs;

namespace Service.Mapping
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<PersonCreateDTO,Person>();
            CreateMap<PersonResponseDTO,Person>();
            CreateMap<PersonUpdateDTO,Person>();
            
            CreateMap<NoteCreateDTO, Note>();
            CreateMap<NoteResponseDTO, Note>();
            CreateMap<NoteUpdateDTO, Note>();
        }
    }
}
