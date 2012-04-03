using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookinigPortal.Models;

namespace BookinigPortal.Controllers
{ 
    public class NewsController : Controller
    {
        private BookingModelContainer db = new BookingModelContainer();

        //
        // GET: /News/

        public ViewResult Index()
        {
            var curDate = System.DateTime.Now.Date;

            var newsColl = from s in db.News
                           where s.Status == 1 && s.ReleaseDate <= curDate
                           && (s.ExpiryDate ==null || s.ExpiryDate>=curDate)
                           select s;
            return View(newsColl.ToList());
        }

        public ViewResult Admin()
        {
            var newsColl = from s in db.News
                           select s;
            return View(newsColl.ToList());
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(Guid id)
        {
            News news = db.News.Find(id);
            return View(news);
        }

        public ActionResult DetailsDialog(Guid id)
        {
            News news = db.News.Find(id);
            return View(news);
        }
        //
        // GET: /News/Create

        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.ID = Guid.NewGuid();
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(news);
        }
        
        //
        // GET: /News/Edit/5

        [ValidateInput(false)]
        public ActionResult Edit(Guid id)
        {
            News news = db.News.Find(id);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            News news = db.News.Find(id);
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}