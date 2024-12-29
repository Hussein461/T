using Hospital.Models;
using Hospital.ViewModel;

namespace Hospital.Repos.interfaces
{
    public interface IAppointment
    {
        public Task <IEnumerable<Appointment>> GetAll();
        public Task   Create(AppointmentViewModel appointment);
        public Task   Update(AppointmentViewModel appointment);
        public Task<Appointment>   GetAppointmentbyid( int id);
    }
}
