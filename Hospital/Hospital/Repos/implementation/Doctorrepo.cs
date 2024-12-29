using System;
using Hospital.Models;
using Hospital.Repos.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repos.implementation
{
    public class DoctorRepo : IDoctor
    {
        private readonly Appdbcontext db;

        public DoctorRepo(Appdbcontext appDbContext)
        {
            db = appDbContext;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await db.doctors.ToListAsync();
        }

        public async Task Create(Doctor doctor)
        {
            await db.doctors.AddAsync(doctor);
            await db.SaveChangesAsync();
        }

     
    }
}
