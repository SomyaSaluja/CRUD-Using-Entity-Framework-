using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserSessionManagment.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace UserSessionManagment.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/

        public ActionResult Index()
        {
            return View("~/Views/UserLogin/LoginView.cshtml");
        } 

        [HttpPost]
        public ActionResult Index(UserModel uc)
        {
            if (ModelState.IsValid) 
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select Name , Password from [dbo].[UserTable] where Name=@Name and Password=@Password";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Name", uc.Name);
                        command.Parameters.AddWithValue("@Password", uc.Password);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            Session["Name"] = uc.Name.ToString();
                            return RedirectToAction("DashBoard", "UserLogin");
                        }
                        else
                        {

                            ViewData["Message"] = "Not a registered user";
                            return View("~/Views/UserLogin/ErrorView.cshtml");
                        }
                    }
                }
            }
            return View("~/Views/UserLogin/LoginView.cshtml" ,uc);
            
        }

       
        public ActionResult DashBoard()
        {
            return View("~/Views/UserLogin/DashBoardView.cshtml");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "UserLogin");
        }

        public ActionResult AddEmployee(){
            return View("~/Views/UserLogin/AddEmployee.cshtml");
        }
        public ActionResult UpdateEmployee(int id)
        {
            ViewBag.id = id;
            return View("~/Views/UserLogin/UpdateEmployee.cshtml");
        }
        public ActionResult DeleteEmployee()
        {
            return View();
        }
    }
}
