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
<<<<<<< HEAD
        //ServerSide10

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            string search = Request.QueryString.Get("query");

=======

        public bool getData()
        {
<<<<<<< HEAD
            SqlConnection sqlConnection = new SqlConnection(Data.ConnectionString);
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["library2"].ConnectionString);
             
            try
            {
                sqlConnection2.Open();
                System.Diagnostics.Debug.WriteLine("det fungerar!");
=======
>>>>>>> origin/master
            SqlConnection connect = new SqlConnection(Data.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BOOK WHERE title LIKE '%" + search + "%'");
                SqlDataReader reader = null;

                connect.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                ViewBag.SearchBook = reader["title"].ToString();

<<<<<<< HEAD
=======
                connect.Close();
>>>>>>> origin/master
>>>>>>> origin/master
            }
            catch (Exception e)
            { 

            }
            finally 
            {
<<<<<<< HEAD
                connect.Close();
            }

=======
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

>>>>>>> origin/master
            return View("search");
        }

        public ActionResult Login()
        {
<<<<<<< HEAD
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
                return View("borrower");
=======
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
>>>>>>> origin/master
        }

        public ActionResult Browse()
        {
            return View("search");
        }

    
    }
}
