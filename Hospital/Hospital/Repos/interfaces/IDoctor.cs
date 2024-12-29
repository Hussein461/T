using Hospital.Models;

namespace Hospital.Repos.interfaces
{
    public interface IDoctor
    {
       
        public Task <IEnumerable<Doctor>> GetAll();
        public Task Create(Doctor doctor);
    }
}
