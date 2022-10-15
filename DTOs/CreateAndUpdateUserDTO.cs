using BackendFinalGrupo10.Entitys;
using System.ComponentModel.DataAnnotations;

namespace BackendFinalGrupo10.DTOs
{
    public class CreateAndUpdateUserDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
