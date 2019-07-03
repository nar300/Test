using MVC_5Temp.Data;
using MVC_5Temp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_5Temp.Controllers
{
    public class StaffController : Controller
    {
        CustomerDBContext db = new CustomerDBContext();
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //}
        // GET: Staff
        public ActionResult Index()
        {
            var customer = db.Customers.ToList();
            return View(customer);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Customer customer)
        //{
        //    db.Customers.Add(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("index");
        //}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task< ActionResult> AjDelete(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
          await  db.SaveChangesAsync();
            var customers = db.Customers;
            return PartialView("Myclients", customers);
        }
       [HttpGet]
       public ActionResult AjCreate()
        {
            
            return PartialView(new Customer());
        }
        [HttpPost]
        public async Task< ActionResult> AJCreate(Customer customer)
        {
            db.Entry(customer).State = EntityState.Added;
            await db.SaveChangesAsync();

            var customers = db.Customers;
            return PartialView("Myclients", customers);
        }
        [HttpGet]
        public ActionResult AJEdit(int id)
        {
            var customer = db.Customers.Find(id);
           
            return PartialView(customer);
        }
        [HttpPost]
        public async Task<ActionResult> AJEdit(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            await db.SaveChangesAsync();

            var customers = db.Customers;
            return PartialView("Myclients", customers);
        }
        
    }
}