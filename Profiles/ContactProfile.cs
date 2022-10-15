using AutoMapper;
using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;

namespace BackendFinalGrupo10.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateAndUpdateContactDTO>();
            CreateMap<CreateAndUpdateContactDTO, Contact>();
        }
        

    }
}
