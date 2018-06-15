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
    public class contactsController : Controller
    {
        private Model1 db = new Model1();

        // GET: contacts
        public ActionResult Index()
        {
            var contacts = db.contacts.Include(c => c.reservation);
            return View(contacts.ToList());
        }

        // GET: contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: contacts/Create
        public ActionResult Create()
        {
            if (TempData.ContainsKey("cId"))
            {
                return RedirectToAction("Edit", new { id = int.Parse(TempData["cId"].ToString()) });
            }
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId");
            return View();
        }

        // POST: contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cId,bId,LastName,FirstName,StreetNumber,City,Province,Country,PostalCode,PhoneNumber,Email")] contact contact)
        {
            if (ModelState.IsValid)
            {
                db.contacts.Add(contact);
                db.SaveChanges();
                TempData["cId"] = contact.cId;
                return RedirectToAction("Create","creditinfoes", new { bId = contact.bId, cId = contact.cId });
            }

            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", contact.bId);
            return View(contact);
        }

        // GET: contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", contact.bId);
            return View(contact);
        }

        // POST: contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cId,bId,LastName,FirstName,StreetNumber,City,Province,Country,PostalCode,PhoneNumber,Email")] contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                string FindContactSql = "select creditId from creditinfo where bId =" + contact.bId;
                int creditid = db.Database.SqlQuery<int>(FindContactSql).FirstOrDefault();
                if (creditid > 0)
                    TempData["creditId"] = creditid;
                else
                    TempData.Remove("creditId");
                return RedirectToAction("Create", "creditinfoes", new { bId = contact.bId, cId = contact.cId });
            }
            ViewBag.bId = new SelectList(db.reservations, "bId", "bId", contact.bId);
            return View(contact);
        }

        // GET: contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
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
