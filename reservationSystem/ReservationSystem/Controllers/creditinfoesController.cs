using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationSystem;

namespace ReservationSystem.Controllers
{
    public class creditinfoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: creditinfoes
        public ActionResult Index()
        {
            var creditinfoes = db.creditinfoes.Include(c => c.contact).Include(c => c.reservation);
            return View(creditinfoes.ToList());
        }

        // GET: creditinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creditinfo creditinfo = db.creditinfoes.Find(id);
            if (creditinfo == null)
            {
                return HttpNotFound();
            }
            return View(creditinfo);
        }

        // GET: creditinfoes/Create
        public ActionResult Create()
        {
            if (TempData.ContainsKey("creditId"))
            {
                return RedirectToAction("Edit", new { id = int.Parse(TempData["creditId"].ToString()) });
            }
            ViewBag.cId = new SelectList(db.contacts, "cId", "cId");
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId");
            return View();
        }

        // POST: creditinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "creditId,cId,bId,cardType,name,cardNumber,expDate")] creditinfo creditinfo)
        {
            if (ModelState.IsValid)
            {
                db.creditinfoes.Add(creditinfo);
                db.SaveChanges();
                //This is last page commit so clear TempData after this
                TempData.Clear();
                return RedirectToAction("Index","reservations");
            }

            ViewBag.cId = new SelectList(db.contacts, "cId", "cId", creditinfo.cId);
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", creditinfo.bId);
            return View(creditinfo);
        }

        // GET: creditinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creditinfo creditinfo = db.creditinfoes.Find(id);
            if (creditinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.cId = new SelectList(db.contacts, "cId", "cId", creditinfo.cId);
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", creditinfo.bId);
            return View(creditinfo);
        }

        // POST: creditinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "creditId,cId,bId,cardType,name,cardNumber,expDate")] creditinfo creditinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            ViewBag.cId = new SelectList(db.contacts, "cId", "cId", creditinfo.cId);
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", creditinfo.bId);
            return View(creditinfo);
        }

        // GET: creditinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creditinfo creditinfo = db.creditinfoes.Find(id);
            if (creditinfo == null)
            {
                return HttpNotFound();
            }
            return View(creditinfo);
        }

        // POST: creditinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            creditinfo creditinfo = db.creditinfoes.Find(id);
            db.creditinfoes.Remove(creditinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
