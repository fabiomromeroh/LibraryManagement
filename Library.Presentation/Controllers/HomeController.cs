using Library.Business;
using Library.Entity;
using Library.Presentation.Core;
using Library.Presentation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBorrowLogic borrowLogic;

        public HomeController(IBorrowLogic borrowLogic)
        {
            this.borrowLogic = borrowLogic;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            List<BorrowedBookModel> borrowedBooksModel = new List<BorrowedBookModel>();
            ViewBag.UserLogged = userId != null;
            if (userId != null)
            {
                var borrowedBooks = this.borrowLogic.GetBorrowedBooksByUser(userId);
                 borrowedBooksModel = ControllerProfile.Mapper.Map<List<BorrowedBook>, List<BorrowedBookModel>>(borrowedBooks);
            }
            return View(borrowedBooksModel);
        }

    }
}