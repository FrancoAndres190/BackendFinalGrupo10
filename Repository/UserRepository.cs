using AutoMapper;
using BackendFinalGrupo10.Context;
using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;
using BackendFinalGrupo10.Repository.Interfaces;

namespace BackendFinalGrupo10.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public void Create(CreateAndUpdateUserDTO dto)
        {
            _context.Users.Add(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateUserDTO dto, int id)
        {
            User user = _mapper.Map<User>(dto);
            user.Id = id;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }

        public User? ValidateUser(AuthenticationDto authDto)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authDto.UserName && p.Password == authDto.Password);
        }

    }
}
