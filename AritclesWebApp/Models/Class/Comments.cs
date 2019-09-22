using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Class
{
    public class Comments : Posts
    {
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Ip { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public Nullable<int> ParentId { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
