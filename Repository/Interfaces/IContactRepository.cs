using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;

namespace BackendFinalGrupo10.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();

        public void Create(CreateAndUpdateContactDTO dto);

        
        public void Update(CreateAndUpdateContactDTO dto, int id);

       
        public void Delete(int id);
    }
}
