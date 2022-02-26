using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    
    public class BookRepository : IBookRepositories<Books>
    {
        List<Books> books;
        public BookRepository()
        {
            books = new List<Books>()
        {
            new Books
            {
                Id=1,BookName="C++",Description="No Description",
            },
             new Books
            {
                Id=2,BookName="C Sharp",Description="Description",
            },
              new Books
            {
                Id=3,BookName="Python",Description="DESCRIPTION",
            },
        };
        }
        public void Add(Books entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Books Find(int id)
        {
            var book = books.SingleOrDefault(x => x.Id == id);
            return book;
        }

        public IList<Books> List()
        {
            return books;
        }

        public void Update(int id,Books entity)
        {
            var book = Find(id);
            book.Id = entity.Id;
            book.BookName = entity.BookName;
            book.Description = entity.Description;
            book.Authors = entity.Authors;
        }

      
    }
}
