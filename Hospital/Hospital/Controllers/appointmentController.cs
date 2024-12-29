using Hospital.Models;
using Hospital.Repos.interfaces;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointment appointmentRepo;
        private readonly IDoctor doctorRepo;
        private readonly IPatient patientRepo;

        public AppointmentController(IAppointment appointment, IDoctor doctor, IPatient patient)
        {
            appointmentRepo = appointment;
            doctorRepo = doctor;
            patientRepo = patient;
        }

        public async Task<IActionResult> GetAll()
        {
            var allAppointments = await appointmentRepo.GetAll();
            return View(allAppointments);
        }

        public async Task<IActionResult> Create()
        {
            var doctors = await doctorRepo.GetAll();
            var patients = await patientRepo.GetAll();

            var appointmentViewModel = new AppointmentViewModel
            {
                doctors = doctors.ToList(),
                patients = patients.ToList()
            };

            return View(appointmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel appointmentViewModel)
        {
            await appointmentRepo.Create(appointmentViewModel);

            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(int id) 
        {
            var app = await appointmentRepo.GetAppointmentbyid(id);
            var pat = await patientRepo.GetAll();
            var doc = await doctorRepo.GetAll();
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel()
            {
                DateTime = app.Date,
                Notes = app.Notes,
                patients = pat.ToList(),
                doctors = doc.ToList(),
            };
            return View(appointmentViewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppointmentViewModel appointmentViewModel)
        {
            await appointmentRepo.Update(appointmentViewModel);
            return RedirectToAction("GetAll");
        }
    }
}
