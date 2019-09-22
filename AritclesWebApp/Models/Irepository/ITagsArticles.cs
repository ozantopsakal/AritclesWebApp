using AritclesWebApp.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AritclesWebApp.Models.Irepository
{
    public interface ITagsArticles
    {
        TagsArticles GetTagsArticles(int id);
        IEnumerable<TagsArticles> GetAllTagsArticles();
        TagsArticles Add(TagsArticles tagsArticles);
        TagsArticles Update(TagsArticles changedTagsArticles);
        TagsArticles Delete(int id);
    }
}
