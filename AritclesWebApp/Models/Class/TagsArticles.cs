using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Class
{
    public class TagsArticles : DbContext
    {
        public int Id { get; set; }
        public int TagsId { get; set; }
        public int ArticlesId { get; set; }

        public Tags Tag { get; set; }
        public Articles Article { get; set; }
    }
}
