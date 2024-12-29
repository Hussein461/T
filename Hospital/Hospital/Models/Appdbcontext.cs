using Microsoft.EntityFrameworkCore;

namespace Hospital.Models
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext>option):base(option) { }
        
        public  DbSet<Doctor> doctors {  get; set; }
       public  DbSet<Patient> Patient {  get; set; }
       public  DbSet<Appointment> Appointment{  get; set; }
    }
}
