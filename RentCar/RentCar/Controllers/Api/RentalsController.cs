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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentCar.Dtos;
using RentCar.Models;

namespace RentCar.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Rentals
        public IHttpActionResult GetRentals()
        {
            var rentals = db.Rentals.Include(c => c.Car).Include(cu => cu.Customer).ToList()
                .Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rentals);
        }
        // POST: api/Rentals
        [ResponseType(typeof(RentalDto))]
        public IHttpActionResult PostRental(RentalDto rentalDto)
        {
            if (rentalDto.CarIds.Count == 0)
            {
                return BadRequest("No movies have been given.");
            }
            var customer = db.Customers.SingleOrDefault(cus => cus.Id == rentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Invalid custmer ID");
            }
            var cars = db.Cars.Where(c => rentalDto.CarIds.Contains(c));


            foreach (var car in cars)
            {
                if (car.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                car.NumberAvailable--;

                db.Rentals.Add(new Rental
                {
                    Car = car,
                    Customer = customer,
                    RentalDate = DateTime.Now
                });
            }
            db.SaveChanges();

            // In this action We are not creating a single new object          
            // return Created(new Uri(Request.RequestUri + "/" + rentalDto.Id), rentalDto);
            return Ok();
        }
        /*All this was for practice lalala..*/
        //        // GET: api/Rentals/5
        //        [ResponseType(typeof(RentalDto))]
        //        public IHttpActionResult GetRental(int id)
        //        {
        //            var rental = db.Rentals.SingleOrDefault(r => r.Id == id);
        //            if (rental == null)
        //            {
        //                return NotFound();
        //            }
        //            var rentalDto = Mapper.Map<Rental, RentalDto>(rental);
        //            return Ok(rentalDto);
        //        }
        //
        //        // PUT: api/Rentals/5
        //        [ResponseType(typeof(void))]
        //        public IHttpActionResult PutRental(int id, RentalDto rentalDto)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }
        //
        //            var rental = db.Rentals.SingleOrDefault(r => r.Id == id);
        //            if (rental == null)
        //            {
        //                return NotFound();
        //            }
        //
        //            Mapper.Map<RentalDto, Rental>(rentalDto,rental);
        //            db.SaveChanges();
        //
        //            return StatusCode(HttpStatusCode.NoContent);
        //        }
        //

        //
        //        // DELETE: api/Rentals/5
        //        [ResponseType(typeof(Rental))]
        //        public IHttpActionResult DeleteRental(int id)
        //        {
        //            var rental = db.Rentals.SingleOrDefault(r => r.Id == id);
        //            if (rental == null)
        //            {
        //                return NotFound();
        //            }
        //
        //            db.Rentals.Remove(rental);
        //            db.SaveChanges();
        //
        //            return Ok(rental);
        //        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalExists(int id)
        {
            return db.Rentals.Count(e => e.Id == id) > 0;
        }
    }
}