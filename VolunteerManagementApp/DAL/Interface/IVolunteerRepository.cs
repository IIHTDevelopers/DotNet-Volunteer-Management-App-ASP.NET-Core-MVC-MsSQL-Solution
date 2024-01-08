
using VolunteerManagementApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagementApp.Models;

namespace VolunteerManagementApp.DAL.Interface
{
    public interface IVolunteerRepository
    {
        Volunteer GetVolunteerById(int volunteerId);
        IEnumerable<Volunteer> GetAllVolunteers();
        Volunteer AddVolunteer(Volunteer volunteer);
        Volunteer UpdateVolunteer(Volunteer volunteer);
        Volunteer DeleteVolunteer(int volunteerId);
    }
}