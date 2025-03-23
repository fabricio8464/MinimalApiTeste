using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MinimalAPiTeste.Entities
{
    public class Users_Log
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo Nome deve ser preenchido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email deve ser preenchido, verifique se o mesmo foi preenchido ou se é um email valido"), EmailAddress]
        public string Email { get; set; }
        [AllowNull]
        public DateTime Ultimo_Login { get; set; }
    }
}
