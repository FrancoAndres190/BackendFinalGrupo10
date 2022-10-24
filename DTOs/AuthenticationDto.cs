using System.ComponentModel.DataAnnotations;

namespace BackendFinalGrupo10.DTOs
{
    public class AuthenticationDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
