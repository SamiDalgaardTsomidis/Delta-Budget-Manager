using Oprettelse_Af_Budget.Models;
using System;
using System.Collections.Generic;
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
                domainModel.AddTransaction(cm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new Container());
            }
        }
    }
}