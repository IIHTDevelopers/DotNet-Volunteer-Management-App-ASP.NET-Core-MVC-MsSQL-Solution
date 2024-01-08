using VolunteerManagementApp.DAL.Interface;
using VolunteerManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace VolunteerManagementApp.DAL.Repository
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private VolunteerDbContext _context;
        public VolunteerRepository(VolunteerDbContext Context)
        {
            this._context = Context;
        }
      
        public Volunteer GetVolunteerById(int volunteerId)
        {
            return _context.Volunteers.Find(volunteerId);
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return _context.Volunteers.ToList();
        }

        public Volunteer AddVolunteer(Volunteer volunteer)
        {
            if (volunteer != null)
            {
                _context.Volunteers.Add(volunteer);
                _context.SaveChanges(); // Save changes to the database
                return volunteer; // Return the added volunteer with the updated Id
            }
            else
            {
                // Handle the case where the input volunteer is null
                throw new ArgumentNullException(nameof(volunteer), "Volunteer object cannot be null");
            }
        }


        public Volunteer UpdateVolunteer(Volunteer updatedVolunteer)
        {
            if (updatedVolunteer != null)
            {
                var existingVolunteer = _context.Volunteers.Find(updatedVolunteer.VolunteerId);

                if (existingVolunteer != null)
                {
                    // Update properties of the existing volunteer with the new values
                    _context.Entry(existingVolunteer).CurrentValues.SetValues(updatedVolunteer);
                    _context.SaveChanges(); // Save changes to the database
                    return existingVolunteer;
                }
                else
                {
                    // Handle the case where the volunteer with the given Id is not found
                    throw new ArgumentException($"Volunteer with Id {updatedVolunteer.VolunteerId} not found", nameof(updatedVolunteer));
                }
            }
            else
            {
                // Handle the case where the input volunteer is null
                throw new ArgumentNullException(nameof(updatedVolunteer), "Updated volunteer object cannot be null");
            }
        }

        public Volunteer DeleteVolunteer(int volunteerId)
        {
            var volunteerToDelete = _context.Volunteers.Find(volunteerId);

            if (volunteerToDelete != null)
            {
                _context.Volunteers.Remove(volunteerToDelete);
                _context.SaveChanges(); // Save changes to the database
                return volunteerToDelete;
            }
            else
            {
                // Handle the case where the volunteer with the given Id is not found
                throw new ArgumentException($"Volunteer with Id {volunteerId} not found", nameof(volunteerId));
            }
        }
    }
}
