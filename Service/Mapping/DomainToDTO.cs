using AutoMapper;
using Domain.Entities;
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


        }
    }
}
