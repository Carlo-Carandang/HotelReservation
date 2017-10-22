using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class CustomerInformationsController : Controller
    {
        private CustomerModel db = new CustomerModel();

        // GET: CustomerInformations
        public ActionResult Index()
        {
            return View(db.CustomerInformations.ToList());
        }

        // GET: CustomerInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // GET: CustomerInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,StreetNumber,StreetName,City,ProvState,Country,PostalCode,PhoneNumber,Email,CheckInDate,CheckOutDate,Room,Guest,CreditCardType,CreditCardName,CreditCardNumber,CreditCardExpiryDate")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInformations.Add(customerInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerInformation);
        }

        // GET: CustomerInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // POST: CustomerInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,StreetNumber,StreetName,City,ProvState,Country,PostalCode,PhoneNumber,Email,CheckInDate,CheckOutDate,Room,Guest,CreditCardType,CreditCardName,CreditCardNumber,CreditCardExpiryDate")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInformation);
        }

        // GET: CustomerInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // POST: CustomerInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            db.CustomerInformations.Remove(customerInformation);
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
