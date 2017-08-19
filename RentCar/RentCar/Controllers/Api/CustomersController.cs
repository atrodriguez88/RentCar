using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentCar.Models;
using RentCar.Dtos;
using AutoMapper;

namespace RentCar.Controllers.Api
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Customers
        [Route("")]
        [Route("{id:alpha}")]
        public IHttpActionResult GetCustomers(string id = null) // Id is string because you can find for Name
        {
            var customersQuery =  db.Customers.Include(c=>c.MembershipType);
            if (!String.IsNullOrWhiteSpace(id))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(id));
            }
            var customerDtos = customersQuery.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            Mapper.Map<CustomerDto, Customer>(customerDto,customer);

            //cust.Birthdate = customer.Birthdate;
            //cust.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
            //cust.LastName = customer.LastName;
            //cust.MembershipType = customer.MembershipType;
            //cust.Name = customer.Name;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/"+customerDto.Id),customerDto);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.SingleOrDefault(c =>c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}