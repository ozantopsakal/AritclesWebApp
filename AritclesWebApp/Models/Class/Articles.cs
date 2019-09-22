using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Class
{
    public class Articles : Posts
    {
        public string SubTitle { get; set; }
        [Required]
        public bool AllowsComments { get; set; }
        [MaxLength(350)]
        public string ThumbnailPhoto { get; set; }
        [MaxLength(350)]
        public string Photo { get; set; }
        [Required]
        [MaxLength(2)]
        public string Language { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool Active { get; set; }
        public Nullable<int> CategoryId { get; set; }
    }
}
