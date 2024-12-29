using Hospital.Models;

namespace Hospital.Repos.interfaces
{
    public interface IPatient
    {
        public Task<IEnumerable<Patient>> GetAll();
        public Task Create(Patient patient);
    }
}
