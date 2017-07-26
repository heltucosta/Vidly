using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershiptTypes = _context.MembershipTypes.ToList();

            var model = new NewCustomerViewModel()
            {
                MembershipTypes = membershiptTypes
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            // Even though the view is sending a NewCustomerViewModel, .Net Understands
            // the casting to Customer since is part of the model and makes the model binding
            // occur automatically when saving to database
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View("New", viewModel);
        }
        
        // GET: Customer
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // ToList() makes sure the query is done right away

            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}