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
        //
        // GET: /Library/
        //string sqlLoginStr = "user id=sa;" + "password=I will study M0RE!;" + "server=193.10.30.7/TESTSERVER/SQLEXPRESS;" + "Trusted_Connection=yes;" + "Database=DBlib;" + "connection timeout=10;";
        //ServerSide10

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            string search = Request.QueryString.Get("query");

            
            SqlConnection connect = new SqlConnection(Data.ConnectionString);
            
            List<string> bookList = new List<string>();

            try
            {
                //SELECT * fROM BOOK WHERE title = 'Data warehousing data mining and OLAP'
                //LIKE '%" + search + "%'"
                //WHERE title LIKE '%" + search + "%'"
                SqlCommand cmd = new SqlCommand("SELECT * FROM BOOK WHERE title LIKE '%" + search + "%'");
                cmd.Connection = connect;
                SqlDataReader reader = null;

                connect.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookList.Add(reader["Title"].ToString());
                }
                ViewBag.SearchBook = bookList;

            }
            catch (Exception e)
            {
                //ViewBag.SearchBook = "Something was wrong with the connection, contact an administrator.";
                ViewBag.SearchBook = e.Message; 
            }
            finally 
            {
                connect.Close();
            }
            
            return View("search");
        }

        public ActionResult Login()
        {
            SqlConnection connect = new SqlConnection(Data.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR", connect);
                SqlDataReader reader = null;

                connect.Open();

                reader = cmd.ExecuteReader();
                reader.Read();
                ViewBag.AuthorReader = reader["Aid"].ToString();
            }
            catch (Exception e)
            {
            }
            finally 
            {
                connect.Close();
            }


            string user = Request.QueryString.Get("user");
            string pass = Request.QueryString.Get("pass");
            string perm = Request.QueryString.Get("permission");


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
