using LibraryRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LibraryRental.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        public ActionResult New()
        {
            var customer = new Customer();

            return View("CustomerForm", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // TODO: Add insert logic here
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", customer);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.Email = customer.Email;
                customerInDb.Birthdate = customer.Birthdate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View("CustomerForm", customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer.Id == 0) return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}
