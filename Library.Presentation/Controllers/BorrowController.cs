using Core.Validators;
using Library.Business;
using Library.Entity;
using Library.Presentation.Core;
using Library.Presentation.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryPresentation.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBorrowedBookLogic borrowLogic;
        private readonly IBookLogic bookLogic;

        public BorrowController(IBorrowedBookLogic borrowLogic, IBookLogic bookLogic)
        {
            this.borrowLogic = borrowLogic;
            this.bookLogic = bookLogic;
        }
        // GET: Borrow
        public ActionResult Index()
        {
            //I get the current user.
            ViewBag.UserLogged = User.Identity.GetUserId() != null;
            //We get all non borrowed books 
            var books = this.bookLogic.GetAll().ToList();
            //We map the Book entity to BookModel class using AutoMapper. 
            var booksModel = ControllerProfile.Mapper.Map<List<Book>, List<BookModel>>(books);
            return View(booksModel);
        }

        [HttpPost]
        public JsonResult BorrowBook(BorrowBookModel borrowBookModel)
        {
            var result = "Ok";
            try
            {
                var userId = User.Identity.GetUserId();
                this.borrowLogic.BorrowBook(borrowBookModel.BookID, userId, borrowBookModel.Quantity, borrowBookModel.Days);

            }
            catch(ValidationException e)
            {
                result = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        
        public JsonResult ReturnBook(int id)
        {
            var result = "Ok";
            try
            {
                var userId = User.Identity.GetUserId();
                this.borrowLogic.ReturnBook(id);

            }
            catch (ValidationException e)
            {
                result = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}