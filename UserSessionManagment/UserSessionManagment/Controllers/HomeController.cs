using System;
using System.Web;
using System.Web.Mvc;
using UserSessionManagment.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace UserSessionManagment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
