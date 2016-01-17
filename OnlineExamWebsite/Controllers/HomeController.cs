using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineExamWebsite.Controllers
{
  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateQuestion()
        {
            return View("CreateQuestion.html");
        }
    }
}
