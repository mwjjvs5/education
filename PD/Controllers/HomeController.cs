using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PD.Models;
using Microsoft.AspNet.Identity;

namespace PD.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(AddDiaryEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Diary", model);
            }

            var diaryEntry = new DiaryEntry()
            {
                Id = Guid.NewGuid(),
                UserId = User.Identity.GetUserId(),
                Created = DateTime.Now,
                Text = model.Text
            };

            using (var context = new ApplicationDbContext())
            {
                context.DiaryEntries.Add(diaryEntry);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new ApplicationDbContext())
                {
                    var userId = User.Identity.GetUserId();

                    var diaryEntries = context.DiaryEntries
                        .Where(d => d.UserId == userId)
                        .OrderByDescending(d => d.Created);

                    ViewBag.DiaryEntries = diaryEntries.ToList();

                }
                return View("Diary");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

       
    }
}