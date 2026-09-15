using Microsoft.AspNetCore.Mvc;
using Vehicle_Service_Log.Data;
using Vehicle_Service_Log.Models;

namespace Vehicle_Service_Log.Controllers
{
    public class VehiclesController : Controller
    {
        //DI 
        private readonly AppDbContext _db;
        public VehiclesController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            //Entity Framework Approach
            IEnumerable<Vehicle> vehicles = _db.Vehicles.ToList();
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Add(vehicle);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(vehicle);
        }

        //===============
        //Edit
        //==========================
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var vehicle = _db.Vehicles.Find(Id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Update(vehicle);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(vehicle);
        }

        //===============
        //Delete
        //==========================
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var vehicle = _db.Vehicles.Find(Id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Delete(Vehicle vehicle)
        {
            _db.Vehicles.Remove(vehicle);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

