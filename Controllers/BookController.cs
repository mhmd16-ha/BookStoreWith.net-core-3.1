using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{

    public class BookController : Controller
    {
        private readonly IBookRepositories<Books> bookRepository;
        private readonly IBookRepositories<Authors> authorRepository;

        public BookController(IBookRepositories<Books> bookRepository, IBookRepositories<Authors> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var books = bookRepository.Find(id);
            return View(books);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorBookViewModel
            {
                Authors = authorRepository.List().ToList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorBookViewModel entity)
        {
            try
            {
                Books Books = new Books
                {
                    Id = entity.BookId,
                   BookName = entity.BookName,
                   Description=entity.Description,
                   Authors=authorRepository.Find(entity.AuthorId),

                };
                bookRepository.Add(Books);

              
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var books = bookRepository.Find(id);
            return View(books);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Books entity)
        {
            try
            {
                bookRepository.Update(id, entity);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var books = bookRepository.Find(id);
            return View(books);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
