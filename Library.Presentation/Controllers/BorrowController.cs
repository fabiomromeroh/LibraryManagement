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
        private readonly IBorrowLogic borrowLogic;
        private readonly IBookLogic bookLogic;

        public BorrowController(IBorrowLogic borrowLogic, IBookLogic bookLogic)
        {
            this.borrowLogic = borrowLogic;
            this.bookLogic = bookLogic;
        }
        // GET: Borrow
        public ActionResult Index()
        {
            //I get the current user.
            ViewBag.UserLogged = User.Identity.GetUserId() != null;

            var books = this.bookLogic.Find(x => !x.Booked).ToList();
            var booksModel = ControllerProfile.Mapper.Map<List<Book>, List<BookModel>>(books);
            return View(booksModel);
        }

        public JsonResult BorrowBook(int id)
        {
            var result = "Ok";
            try
            {
                var userId = User.Identity.GetUserId();
                this.borrowLogic.BorrowBook(id, userId);

            }
            catch(ValidationException e)
            {
                result = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}