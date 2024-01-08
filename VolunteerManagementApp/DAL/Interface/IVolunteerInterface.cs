using VolunteerManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagementApp.Models;

namespace VolunteerManagementApp.DAL.Interface
{
    public interface IVolunteerInterface 
    {
        Volunteer GetVolunteerById(int volunteerId);
        IEnumerable<Volunteer> GetAllVolunteers();
        Volunteer AddVolunteer(Volunteer volunteer);
        Volunteer UpdateVolunteer(Volunteer volunteer);
        Volunteer DeleteVolunteer(int volunteerId);
    }
}