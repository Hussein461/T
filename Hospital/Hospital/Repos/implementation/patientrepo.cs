using Hospital.Models;
using Hospital.Repos.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repos.implementation
{
    public class patientrepo :IPatient
    {
        private readonly Appdbcontext db;

        public patientrepo(Appdbcontext appDbContext)
        {
            db = appDbContext;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await db.Patient.ToListAsync();
        }

        public async Task Create(Patient patient)
        {
            await db.Patient.AddAsync(patient);
            await db.SaveChangesAsync();
        }
    }
}
