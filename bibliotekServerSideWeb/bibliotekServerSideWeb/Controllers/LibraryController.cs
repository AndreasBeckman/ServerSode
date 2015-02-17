using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bibliotekServerSideWeb.Controllers
{
    public class LibraryController : Controller
    {
        //
        // GET: /Library/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            string search = Request.QueryString.Get("query");

            return View("search");
        }

        public ActionResult Login()
        {
            string user = Request.QueryString.Get("user");
            string pass = Request.QueryString.Get("pass");
            string perm = Request.QueryString.Get("permission");

            if (perm == "borrower")
                return View("borrower");

            if (perm == "admin")
                return View("admin");
            else
                return View("login");
        }

        public ActionResult Browse()
        {
            return View("browse");
        }

        public ActionResult Admin()
        {
            string micke = Request.QueryString.Get("Admin");

            if(micke == "Author Adminpage")
                return View("AuthorAdmin");

            if (micke == "Borrower Adminpage")
                return View("BorrowerAdmin");

            if (micke == "Book Adminpage")
                return View("BookAdmin");

            else
                return View("Admin");
        }
    }
}
