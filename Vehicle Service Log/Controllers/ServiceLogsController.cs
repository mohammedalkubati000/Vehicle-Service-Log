using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Log.Data;
using Vehicle_Service_Log.Models;

namespace Vehicle_Service_Log.Controllers
{
    public class ServiceLogsController : Controller
    {
        //DI 
        private readonly AppDbContext _db;
        public ServiceLogsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
           
            IEnumerable<ServiceLog> logs = _db.ServiceLogs.Include(s => s.Vehicle).ToList();
            return View(logs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            ViewBag.VehicleId = new SelectList(_db.Vehicles.ToList(), "Id", "LicensePlate");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceLog serviceLog)
        {
            if (ModelState.IsValid)
            {
                _db.ServiceLogs.Add(serviceLog);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.VehicleId = new SelectList(_db.Vehicles.ToList(), "Id", "LicensePlate", serviceLog.VehicleId);
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(serviceLog);
        }

        //===============
        //Edit
        //==========================
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var log = _db.ServiceLogs.Find(Id);
            if (log == null)
            {
                return NotFound();
            }

            ViewBag.VehicleId = new SelectList(_db.Vehicles.ToList(), "Id", "LicensePlate", log.VehicleId);
            return View(log);
        }

        [HttpPost]
        public ActionResult Edit(ServiceLog serviceLog)
        {
            if (ModelState.IsValid)
            {
                _db.ServiceLogs.Update(serviceLog);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(_db.Vehicles.ToList(), "Id", "LicensePlate", serviceLog.VehicleId);
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(serviceLog);
        }

        //===============
        //Delete
        //==========================
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var log = _db.ServiceLogs.Include(s => s.Vehicle).FirstOrDefault(s => s.Id == Id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        [HttpPost]
        public ActionResult Delete(ServiceLog serviceLog)
        {
            _db.ServiceLogs.Remove(serviceLog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

