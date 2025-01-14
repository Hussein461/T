﻿namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public string Notes { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }    

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
