using Hospital.Models;
using Hospital.Repos.interfaces;
using Hospital.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repos.implementation
{
    public class appointmentrepo : IAppointment
    {
        private readonly Appdbcontext db;
        public appointmentrepo(Appdbcontext appdbcontext)
        {
            db = appdbcontext;
        }

        public async Task Create(AppointmentViewModel appointment)
        {
            Appointment app_db = new Appointment()
            {
                Date = DateTime.Now,
                Notes = appointment.Notes,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,

            };
            await db.Appointment.AddAsync(app_db);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await db.Appointment.Include(x => x.Patient).Include(x => x.Doctor).ToListAsync();

        }

        public async Task<Appointment> GetAppointmentbyid(int id)
        {
            return await db.Appointment.Include(x => x.Patient).Include(x => x.Doctor).FirstOrDefaultAsync();

        }

        public async Task Update(AppointmentViewModel appointment)
        {
            var upd = await db.Appointment.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            upd.Date = appointment.DateTime;
            upd.Notes = appointment.Notes;
            upd.PatientId = appointment.PatientId;
            upd.DoctorId = appointment.DoctorId;

            await db.SaveChangesAsync();
    
        }
    }
}
