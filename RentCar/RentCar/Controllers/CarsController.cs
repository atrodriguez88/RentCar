using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RentCar.Models;
using RentCar.ViewModel;

namespace RentCar.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Brand).ToList();
            if (User.IsInRole(RoleName.SuperAdmin))
                return View("Index", cars);
            return View("IndexUser", cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var car = db.Cars.Include(c => c.Brand).FirstOrDefault(c => c.Id == id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Create()
        {
            var newCar = new CarFormViewModel
            {
                Brands = db.Brands.ToList()
            };
            return View(newCar);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Create([Bind(Include = "Id,ReleaseDate,Miles,Stock,Brand_Id")] Car car)
        {
            if (ModelState.IsValid)
            {
                var brand = db.Brands.FirstOrDefault(b => b.Id == car.Brand_Id);
                car.Brand = brand;
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var car = db.Cars.Find(id);
            if (car == null)
                return HttpNotFound();
            var editCar = new CarFormViewModel
            {
                Car = car,
                Brands = db.Brands.ToList()
            };
            return View(editCar);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Edit([Bind(Include = "Id,ReleaseDate,Miles,Stock,Brand_Id")] Car car)
        {
            if (ModelState.IsValid)
            {
                var brand = db.Brands.FirstOrDefault(b => b.Id == car.Brand_Id);
                //db.Entry(car).State = EntityState.Modified;       This line does not work in this case

                var carU = db.Cars.Single(c => c.Id == car.Id);
                carU.Miles = car.Miles;
                carU.ReleaseDate = car.ReleaseDate;
                carU.Stock = car.Stock;
                carU.Brand = brand;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var car = db.Cars.Find(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult DeleteConfirmed(int id)
        {
            var car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}