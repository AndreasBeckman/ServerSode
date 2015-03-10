using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace bibliotekServerSideWeb.Controllers
{
    public class LibraryController : Controller
    {
        string id = "";
        //
        // GET: /Library/
        //string sqlLoginStr = "user id=sa;" + "password=I will study M0RE!;" + "server=193.10.30.7/TESTSERVER/SQLEXPRESS;" + "Trusted_Connection=yes;" + "Database=DBlib;" + "connection timeout=10;";
        //ServerSide10
        public bool getData()
        {
            SqlConnection connect = new SqlConnection(Data.ConnectionString);
             
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR", connect);
                SqlDataReader reader = null;



                connect.Open();

                reader = cmd.ExecuteReader();
                reader.Read();
                id = reader["Aid"].ToString();

                connect.Close();
            }
            catch (Exception e)
            {
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
            getData();
            string user = Request.QueryString.Get("user");
            string pass = Request.QueryString.Get("pass");
            string perm = Request.QueryString.Get("permission");
            ViewBag.AuthorReader = id;
            if (perm == "borrower")
                return View("Borrower");

            if (perm == "admin")
                return View("Admin");
            else
                return View("Login");
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
