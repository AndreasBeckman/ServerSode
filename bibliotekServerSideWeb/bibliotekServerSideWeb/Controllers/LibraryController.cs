using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace bibliotekServerSideWeb.Controllers
{
    public class LibraryController : Controller
    {
        //
        // GET: /Library/
        string sqlLoginStr = "user id=sa;" + "password=I will study M0RE!;" + "server=193.10.30.7/TESTSERVER/SQLEXPRESS;" + "Trusted_Connection=yes;" + "Database=DBlib;" + "connection timeout=10;";

        public bool getData()
        {
            SqlConnection sqlConnection = new SqlConnection(Data.ConnectionString);

            try
            {
                sqlConnection.Open();
                System.Diagnostics.Debug.WriteLine("det fungerar!");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("-----------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("This is the problem:");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }


            return true;
        }


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
            if (getData())
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
            else
                return View("Index");
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
