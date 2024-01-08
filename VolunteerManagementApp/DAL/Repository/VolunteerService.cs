using VolunteerManagementApp.DAL.Interface;
using VolunteerManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VolunteerManagementApp.DAL.Repository
{
    public class VolunteerManagementService : IVolunteerInterface
    {
        private IVolunteerRepository _repo;
        public VolunteerManagementService(IVolunteerRepository repo)
        {
            this._repo = repo;
        }

        public Volunteer AddVolunteer(Volunteer volunteer)
        {
            return _repo.AddVolunteer(volunteer);
        }

        public Volunteer DeleteVolunteer(int volunteerId)
        {
            return _repo.DeleteVolunteer(volunteerId);
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return _repo.GetAllVolunteers();
        }

        public Volunteer GetVolunteerById(int volunteerId)
        {
            return _repo.GetVolunteerById(volunteerId);
        }

        public Volunteer UpdateVolunteer(Volunteer volunteer)
        {
            return _repo.UpdateVolunteer(volunteer);
        }
    }
}