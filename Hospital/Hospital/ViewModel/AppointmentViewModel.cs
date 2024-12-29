using Hospital.Models;

namespace Hospital.ViewModel
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Notes {  get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public List<Doctor> doctors { get; set; }
        public List<Patient> patients { get; set; }
    }
}
