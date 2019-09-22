using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Class
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        [MaxLength(350)]
        public string Photo { get; set; }
        public string Bio { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
