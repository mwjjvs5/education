using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PD.Controllers
{
    public class DiaryController : Controller
    {
        // GET: Diary
        
        public ActionResult Index()
        {
            return View("Diary");
        }
    }
}