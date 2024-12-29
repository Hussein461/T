namespace Hospital.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int Age { get; set; }
        public int Gender {  get; set; }
        public string Name { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}
