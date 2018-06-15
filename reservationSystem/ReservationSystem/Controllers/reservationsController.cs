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
    public class reservationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: reservations
        public ActionResult Index()
        {
            return View(db.reservations.ToList());
        }

        // GET: reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservations/Create
        public ActionResult Create()
        {
            if (TempData.ContainsKey("bId"))
            {
                return RedirectToAction("Edit",new { id = int.Parse(TempData["bId"].ToString()) });
            }
            
            reservation resv = new reservation();
            var counts = getAllGuestsAndRoomsCounts();

            // Set these number counts in the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of guests/rooms.
            resv.counts = getSelectListItems(counts);
            return View(resv);
        }

        // POST: reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bId,checkInDate,checkOutDate,noOfGuest,noOfRooms")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservation);
                db.SaveChanges();
                TempData["bId"] = reservation.bId;
                return RedirectToAction("Create", "contacts", new { bId = reservation.bId });
            }
            var counts = getAllGuestsAndRoomsCounts();
            reservation.counts = getSelectListItems(counts);
            return View(reservation);
        }

        // GET: reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var counts = getAllGuestsAndRoomsCounts();
            reservation.counts = getSelectListItems(counts);
            return View(reservation);
        }

        // POST: reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bId,checkInDate,checkOutDate,noOfGuest,noOfRooms")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                string FindContactSql = "select cId from Contact where bId =" + reservation.bId;
                int cid = db.Database.SqlQuery<int>(FindContactSql).FirstOrDefault();
                if (reservation.bId > 0)
                    TempData["bId"] = reservation.bId;
                else
                    TempData.Remove("bId");
                if (cid > 0)
                    TempData["cId"] = cid;
                else
                    TempData.Remove("cId");
                return RedirectToAction("Create", "contacts", new { bId = reservation.bId });
            }
            var counts = getAllGuestsAndRoomsCounts();
            reservation.counts = getSelectListItems(counts);
            return View(reservation);
        }

        // GET: reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            string deleteCreditcardSql = "delete from creditinfo where bID =" + reservation.bId;
            db.Database.ExecuteSqlCommand(deleteCreditcardSql);
            string deleteContactSql = "delete from contact where bID =" + reservation.bId;
            db.Database.ExecuteSqlCommand(deleteContactSql);
            db.reservations.Remove(reservation);
            db.SaveChanges();
            //clean all the session data.
            TempData.Clear();
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
        private IEnumerable<string> getAllGuestsAndRoomsCounts()
        {
            return new List<string>
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20"
            };
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> getSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}
