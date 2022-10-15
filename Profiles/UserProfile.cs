using AutoMapper;
using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;

namespace BackendFinalGrupo10.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateAndUpdateUserDTO>();
            CreateMap<CreateAndUpdateUserDTO, User>();
        }
    }
}
