﻿using System;
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

        public ReservationContext Db { get => db; set => db = value; }

        // -----------------------------------------------View Reservations--------------------------------
        public ActionResult Index(int id)
        {
            if(Session["Email"]!=null)
                {
                Session["CustomerId"] = id;
                List<Reservation> res = Db.Reservations.Where(reserve => reserve.Cid == id).ToList();
                return View(res);
            }
            else
            {
                return RedirectToAction("LoginCustomer","Customer");
            }
        }

        //-------------------------------------GET: Create a reservation----------------------------------
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
        //------------------------------------POST: Create a reservation-----------------------------------------
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
                Db.Reservations.Add(reservation);
                Db.SaveChanges();
                return RedirectToAction("Index", "Reservation", new { id = a });
            }

            return View();
        }
        //---------------------------------GET: Edit a reservation--------------------------------------------------
        public ActionResult Edit(int? id )
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

            if (id == null || Session["Email"] == null)
            {
                return RedirectToAction("LoginCustomer", "Customer");
            }
            Reservation reservation = Db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }
        //--------------------------------------POST: Edit a reservation--------------------------------------------
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
                Db.Entry(reserve).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index","Reservation",new { id = a });
            }

            return View(reservation);
        }
        //-----------------------------------GET: delete a reservation-------------------------------------------------------
        public ActionResult Delete(int? id)
        {
            if (id == null || Session["Email"]==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = Db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //---------------------------------------POST: Reservations/Delete/5-----------------------------------------------
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int a = Int32.Parse(Session["CustomerId"].ToString());
            Reservation reservation = Db.Reservations.Find(id);
            Db.Reservations.Remove(reservation);
            Db.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { id = a });
        }
    }
}