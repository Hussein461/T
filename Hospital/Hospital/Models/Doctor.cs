namespace Hospital.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Speiclization { get; set; }

        public List<Appointment> appointments { get; set; }
    }
}
