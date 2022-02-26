using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModel
{
    public class BookAuthorBookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public List<Authors> Authors { get; set; }


    }
}
