using DebetCredit.Database;
using DebetCredit.Models;
using DebetCredit.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace DebetCredit.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService = new LoginService();
        private PostgresDatabase database = new PostgresDatabase();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reset()
        {
            database.DropTables();
            database.PrepareTables();

            return RedirectToAction("Reg", "Login");
        }

        [HttpGet]
        public ActionResult Reg()
        {
            loginService.RegUser();

            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Auth model)
        {
            var id = loginService.Login(model.Username, model.Password);

            if(id == -1)
            {
                return RedirectToAction("Index", "Login");
            }

            Session["ID"] = id.ToString();

            return RedirectToAction("Index", "Balance");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Login");
        }
    }
}