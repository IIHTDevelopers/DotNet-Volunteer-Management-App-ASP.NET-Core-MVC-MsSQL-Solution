using Microsoft.AspNetCore.Mvc;
using VolunteerManagementApp.DAL.Interface;
using VolunteerManagementApp.Models;

namespace VolunteerManagementApp.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerInterface _volunteerRepository;

        public VolunteerController(IVolunteerInterface volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        // GET: /Volunteer/Index
        public IActionResult Index()
        {
            var volunteers = _volunteerRepository.GetAllVolunteers();
            return View(volunteers);
        }

        // GET: /Volunteer/Details/{id}
        public IActionResult Details(int id)
        {
            var volunteer = _volunteerRepository.GetVolunteerById(id);

            if (volunteer == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(volunteer);
        }

        // GET: /Volunteer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Volunteer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _volunteerRepository.AddVolunteer(volunteer);
                return RedirectToAction("Index");
            }

            return View(volunteer);
        }

        // GET: /Volunteer/Edit/{id}
        public IActionResult Edit(int id)
        {
            var volunteer = _volunteerRepository.GetVolunteerById(id);

            if (volunteer == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(volunteer);
        }

        // POST: /Volunteer/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Volunteer updatedVolunteer)
        {
            if (id != updatedVolunteer.VolunteerId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _volunteerRepository.UpdateVolunteer(updatedVolunteer);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedVolunteer);
        }

        // GET: /Volunteer/Delete/{id}
        public IActionResult Delete(int id)
        {
            var volunteer = _volunteerRepository.GetVolunteerById(id);

            if (volunteer == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(volunteer);
        }

        // POST: /Volunteer/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedVolunteer = _volunteerRepository.DeleteVolunteer(id);

            if (deletedVolunteer == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
