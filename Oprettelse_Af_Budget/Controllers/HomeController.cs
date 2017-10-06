using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oprettelse_Af_Budget.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            //Sami er en G*
            //Sami Stinker
        }
        public ActionResult Create()
        {
            return View(new Container());
        }

        [HttpPost]
        public ActionResult Create(Container cm)
        {
            try
            {
                var domainModel = new DB();
                domainModel.CreateSomething(cm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new Container());
            }
        }
    }
}