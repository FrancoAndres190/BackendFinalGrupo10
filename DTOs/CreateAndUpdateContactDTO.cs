using BackendFinalGrupo10.Entitys;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendFinalGrupo10.DTOs
{
    public class CreateAndUpdateContactDTO
    {
        [Required]
        public string Name { get; set; }
        public string Number { get; set; }

        public string Description = string.Empty;

        public User? User;
        //public int UserId { get; set; }

    }
}
