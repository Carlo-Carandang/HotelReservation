using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Reserve.Models;
namespace Hotel_Reserve.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext db = new CustomerContext();
        CountryState db1 = new CountryState();

        //---------------------------------- GET: Register Customer-----------------------------------------------
        public ActionResult RegisterCustomer()
        {
            List<Country> CountryList = db1.Countries.ToList();
            ViewBag.CountryList = new SelectList(CountryList,"CountryName","CountryName");
            Customer customerModel = new Customer();
            return View(customerModel);
        }

        public JsonResult GetStateResult(string CountryName)
        {
            db1.Configuration.ProxyCreationEnabled = false;
            List<State> StateList = db1.States.Where(x => x.CountryName == CountryName).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }
        //---------------------------------- POST: Register Customer----------------------------------------------
        [HttpPost]
        public ActionResult RegisterCustomer(Customer customerModel)
        {
            if (customerModel == null)
            {
                throw new ArgumentNullException(nameof(customerModel));
            }

            using (CustomerContext customerMl = new CustomerContext())
            {
                if (customerMl.Customers.Any(x => x.Email == customerModel.Email))
                {
                    ViewBag.DuplicateMessage = "Customer with this email is already registered";
                    return View("RegisterCustomer", customerModel);
                }
                customerMl.Customers.Add(customerModel);
                customerMl.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return RedirectToAction("Index", "Reservation", new { id = customerModel.id });
        }
        //----------------------------------- GET: Login----------------------------------------------------------------------
        public ActionResult LoginCustomer()
        {
            return View("LoginCustomer");
        }
        //------------------------------------ POST: Login---------------------------------------------------------------------
        [HttpPost]
        public ActionResult AuthorizeCustomer(Customer cust)
        {
            using (CustomerContext db = new CustomerContext())
            {
                var custDetails = db.Customers.Where(x => x.Email == cust.Email && x.Password == cust.Password).FirstOrDefault();
                if (custDetails == null)
                {
                    ViewBag.LoginErrorMessage = "Wrong username or password";
                    return View("LoginCustomer", cust);
                }
                else
                {
                    Session["Email"] = custDetails.Email;
                    Session["Fname"] = custDetails.FirstName;
                    Session["Id"] = custDetails.id;
                    return RedirectToAction("Index", "Reservation", new { id = custDetails.id });
                }
            }
        }
        //-------------------------------------LogOut-----------------------------------------------------------------------------
        public ActionResult LogoutCustomer()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        //-------------------------------------------GET: Customers---------------------------------------------------------------- 
        public ActionResult ViewCustomer()
        {
            if(Session["Email"] == null)
            {
                return View("Error");
            }
            else if(Session["Email"].ToString() == "Adminstrator")
            {
                return View(db.Customers.ToList());
            }
            else
            {
                return View("Error");
            }
            
        }
        //------------------------------------------------Error---------------------------------------------------------------------
        public ActionResult Error()
        {
            return View();
        }
    }
}