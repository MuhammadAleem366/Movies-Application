using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using MVCApp.ViewModels;
namespace MVCApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }
        // GET: Customer/Index
       
        [Authorize]
        public ViewResult Index()
        {
            //if we run the aplication with following code there we get an error because MemberShipType
            //doees not loads so we use Include() method
            //var customers = _context.Customers.ToList();
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }
        public ActionResult CustomerFormModel() {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MemberShipTypes = memberShipTypes
            };
            return View(viewModel);
        }

        //Customer/Create will get data and add Customer to DataBase
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //To access this we have to add Hidden Field in Our Form
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                 }
            else
            {
                var customerInDb = _context.Customers.Include(c => c.MemberShipType).Single(c => c.Id == customer.Id);

                //We can use TryUpdateModel(customerInDb) to update but this has some issues

                //Another method is to do it manually
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Customer");

        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id) {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c =>c.Id ==id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerFormModel",viewModel);
        }
        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ Id=1,Name="Aleem",Email="aleemawan5565@gmail.com" },
                new Customer{ Id=2,Name="Raheem",Email="raheemawan5565@gmail.com" }

            };
        }*/
    }
}