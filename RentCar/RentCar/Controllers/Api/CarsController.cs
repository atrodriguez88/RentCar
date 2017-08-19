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
using AutoMapper;
using RentCar.Dtos;
using System.Web.Routing;

namespace RentCar.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cars
        [Route("")]
        [Route("{id:alpha}")]
        public IHttpActionResult GetCars(string id = null)
        {
            var cars = db.Cars.Include(c => c.Brand).Where(c => c.Id > 0);

            var carsDto = cars.Include(c=>c.Brand).ToList().Select(Mapper.Map<Car, CarDto>);
            return Ok(carsDto);
        }

        // GET: api/Cars/5
        [ResponseType(typeof(CarDto))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.SingleOrDefault(c =>c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Car,CarDto>(car));
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = db.Cars.SingleOrDefault(c => c.Id == carDto.Id);

            if (car == null)
            {
                return NotFound();
            }

            Mapper.Map(carDto,car);

            //car.Brand_Id = carDto.Brand_Id;
            //car.Miles = carDto.Miles;
            //car.ReleaseDate = carDto.ReleaseDate;
            //car.Stock = carDto.Stock;

            db.SaveChanges();

            return Ok();
        }

        // POST: api/Cars
        [ResponseType(typeof(CarDto))]
        public IHttpActionResult PostCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var car = Mapper.Map<CarDto, Car>(carDto);
            db.Cars.Add(car);
            db.SaveChanges();

            carDto.Id = car.Id;

            return Created(new Uri(Request.RequestUri + "/" + car.Id),carDto);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.SingleOrDefault(c =>c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}