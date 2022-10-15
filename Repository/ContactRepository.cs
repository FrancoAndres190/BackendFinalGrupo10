using AutoMapper;
using BackendFinalGrupo10.Context;
using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;
using BackendFinalGrupo10.Repository.Interfaces;
using System.Runtime.Intrinsics.X86;

namespace BackendFinalGrupo10.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public void Create(CreateAndUpdateContactDTO dto)
        {
            _context.Contacts.Add(_mapper.Map<Contact>(dto));
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }


        public void Update(CreateAndUpdateContactDTO dto, int id)
        {
            Contact contact = _mapper.Map<Contact>(dto);
            contact.Id = id;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
    }
}
