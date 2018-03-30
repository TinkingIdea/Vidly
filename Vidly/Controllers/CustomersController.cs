using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
	    private readonly ApplicationDbContext _db;

	    public CustomersController()
	    {
			_db=new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
			_db.Dispose();
	    }

	    public ActionResult New()
	    {
		    var menbershipTypes = _db.MenMembershipTypes.ToList();
		    var viewModel = new NewCustomerViewModel
		    {
				MembershipTypes = menbershipTypes
			};
		    return View("CustomerForm",viewModel);
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewCustomerViewModel
				{
					Customer = new Customer(),
					MembershipTypes = _db.MenMembershipTypes.ToList()
				};
				return View("CustomerForm",viewModel);
			}
			if (customer.Id == 0)
				_db.Customers.Add(customer);
			else
			{
				var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == customer.Id);
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				
			}
			_db.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}
        // GET: Customers
        public ViewResult Index()
        {
	        return View();
        }

	    public ActionResult Details(int id)
	    {
		    var customer = _db.Customers.Include(o=>o.MembershipType).SingleOrDefault(c => c.Id == id);

		    if (customer == null)
			    return HttpNotFound();
		    ViewBag.customer = customer;
		    return View();
	    }

	    public ActionResult Edit(int id)
	    {
		    var customer = _db.Customers.SingleOrDefault(c => c.Id == id);

		    if (customer == null)
			    return HttpNotFound();

		    var viewModel = new NewCustomerViewModel()
		    {
			    Customer = customer,
			    MembershipTypes = _db.MenMembershipTypes.ToList()
		    };

		    return View("CustomerForm",viewModel);
	    }
    }
}