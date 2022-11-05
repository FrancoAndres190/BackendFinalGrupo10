using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendFinalGrupo10.Entitys
{
    public class User
    {
        public enum num_rango{
            normal = 0,
            admin = 45554 //para evitar entradas raras
        };


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        
        public num_rango Rango { get; set; }
        

        public ICollection<Contact> Contacts { get; set; } 


    }
}
