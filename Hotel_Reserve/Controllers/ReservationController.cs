using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Reserve.Models;

namespace Hotel_Reserve.Controllers
{
    public class ReservationController : Controller
    {
        ReservationContext db = new ReservationContext();
        // GET: Reservation
        public ActionResult Index(int id)
        {
            if(Session["Email"]!=null)
                {
                Session["CustomerId"] = id;
                List<Reservation> res = db.Reservations.Where(reserve => reserve.Cid == id).ToList();
                return View(res);
            }
            else
            {
                return RedirectToAction("LoginCustomer","Customer");
            }
        }

        public ActionResult Create()
        {
            List<SelectListItem> ObjItem2 = new List<SelectListItem>()
            {
                new SelectListItem {Text="1",Value="1" },
                new SelectListItem {Text="2",Value="2"},
                new SelectListItem {Text="3",Value="3" },
                new SelectListItem {Text="4",Value="4"},
                new SelectListItem {Text="5",Value= "5"},

            };
            ViewBag.Numbers = ObjItem2;
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginCustomer","Customer");
            }
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reserve)
        {
            int a = Int32.Parse(Session["CustomerId"].ToString());
            Reservation reservation = new Reservation();
            reservation.CheckInDate = reserve.CheckInDate;
            reservation.CheckOutDate = reserve.CheckOutDate;
            reservation.NumberOfGuest = reserve.NumberOfGuest;
            reservation.NumberOfRoom = reserve.NumberOfRoom;
            reservation.Cid = a;
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index", "Reservation", new { id = a });
            }

            return View();
        }

        public ActionResult Edit(int? id )
        {

            if (id == null || Session["Email"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservation reserve)
        {
            int a = Int32.Parse(Session["CustomerId"].ToString());
            Reservation reservation = new Reservation();
            reservation.CheckInDate = reserve.CheckInDate;
            reservation.CheckOutDate = reserve.CheckOutDate;
            reservation.NumberOfGuest = reserve.NumberOfGuest;
            reservation.NumberOfRoom = reserve.NumberOfRoom;
            reservation.Cid = a;

            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index","Reservation",new { id = a });
            }

            return View(reservation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || Session["Email"]==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int a = Int32.Parse(Session["CustomerId"].ToString());
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { id = a });
        }
    }
}