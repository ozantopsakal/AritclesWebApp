using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.TempClasses
{
    public class ArticleTagParameters : Articles
    {
        public List<Tags> TagList { get; set; }
    }
}
