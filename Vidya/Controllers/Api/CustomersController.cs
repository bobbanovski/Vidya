using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidya.Models;

namespace Vidya.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        [HttpPost]
        public Customer NewCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (selectCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            selectCustomer.BirthDate = customer.BirthDate;
            selectCustomer.IsSubscribed = customer.IsSubscribed;
            selectCustomer.MembershipTypeId = customer.MembershipTypeId;
            selectCustomer.Name = customer.Name;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (selectCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(selectCustomer);
            _context.SaveChanges();
        }
    }
}
