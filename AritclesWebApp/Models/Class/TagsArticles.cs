using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Class
{
    public class TagsArticles
    {
        public int Id { get; set; }
        public Nullable<int> TagId { get; set; }
        public Nullable<int> ArticleId { get; set; }
    }
}
