using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookRepositories<Authors>
    {
        List<Authors> authors;
        public AuthorRepository()
        {
            authors = new List<Authors>()
            {
                new Authors{Id=1,AuthorName="Mo"},
                  new Authors{Id=2,AuthorName="so"},
                    new Authors{Id=3,AuthorName="Mohamed"}

            };
        }
        public void Add(Authors entity)
        {
            authors.Add(entity);

        }

        public void Delete(int id)
        {
           var author = Find(id);
            authors.Remove(author);
        }

        public Authors Find(int id)
        {
            var author = authors.SingleOrDefault(b => b.Id == id);
            return author;
        }

        public IList<Authors> List()
        {
            return authors;
        }

      

        public void Update(int id, Authors entity)
        {
            var author = Find(id);
            author.Id = entity.Id;
            author.AuthorName = entity.AuthorName;
        }

       
    }
}
