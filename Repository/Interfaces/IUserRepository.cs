using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;

namespace BackendFinalGrupo10.Repository.Interfaces
{
    public interface IUserRepository
    {
        //public User? ValidateUser(AuthenticationRequestBody authRequestBody);

        public User? GetById(int userId);

        public List<User> GetAll();

        public void Create(User user);

        public void Update(User user);

        public void Delete(int id);

        public User? ValidateUser(AuthenticationDto authDto);

    }
}
