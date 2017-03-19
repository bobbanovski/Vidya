using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidya.Dtos;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //public CustomerDto GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult NewCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer); //EF will update with new Id
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (selectCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, selectCustomer);
            _context.SaveChanges();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (selectCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(selectCustomer);
            _context.SaveChanges();
            return Ok(204);
        }
    }
}