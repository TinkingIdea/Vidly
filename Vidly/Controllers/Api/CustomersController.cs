using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
		private readonly ApplicationDbContext _db;

	    public CustomersController()
	    {
		    _db = new ApplicationDbContext();
	    }
		// GET /api/customers
	    public IHttpActionResult GetCustomers()
	    {
		    var customerDtos= _db.Customers
		        .Include(c=>c.MembershipType)
		        .ToList()
		        .Select(Mapper.Map<Customer,CustomerDto>);
	        return Ok(customerDtos);
	    }

		// GET /api/customers/1
	    public IHttpActionResult GetCustomer(int id)
	    {
		    var customer = _db.Customers.SingleOrDefault(c=>c.Id==id);

	        if (customer == null)
	            return NotFound();

			return Ok(Mapper.Map<Customer,CustomerDto>(customer));
	    }

		// POST /api/customers
		[HttpPost]
	    public IHttpActionResult CreatCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_db.Customers.Add(customer);
			_db.SaveChanges();

			customerDto.Id = customer.Id;


			return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
		}

		// PUT /api/customers/1
	    public void UpdateCustomer(int id, CustomerDto customerDto)
	    {
		    if (!ModelState.IsValid)
			    throw new HttpResponseException(HttpStatusCode.BadRequest);

		    var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == id);

		    if (customerInDb == null)
			    throw new HttpResponseException(HttpStatusCode.NotFound);

		    Mapper.Map(customerDto, customerInDb);

			_db.SaveChanges();
	    }

		// DELETE /api/customers/1
	    [HttpDelete]
	    public void DeleteCustomer(int id)
	    {
		    var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == id);

		    if (customerInDb == null)
			    throw new HttpResponseException(HttpStatusCode.NotFound);

		    _db.Customers.Remove(customerInDb);
		    _db.SaveChanges();
	    }
	}
}
