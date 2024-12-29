using Hospital.Models;
using Hospital.Repos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IDoctor db;
        public DoctorController(IDoctor doctor)
        {
            db = doctor;
        }
        public async Task<IActionResult> GetAll()
        {
            var docs = await db.GetAll();
            return View(docs);
          }
        public async Task<IActionResult> Create()
        {
            return View(new Doctor());
        }
        [HttpPost]

        public async Task<IActionResult> Create(Doctor doctor)
        {
            await db.Create(doctor);
            return RedirectToAction("GetAll");
        }
    }
}
