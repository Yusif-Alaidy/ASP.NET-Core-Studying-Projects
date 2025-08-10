using Microsoft.AspNetCore.Mvc;
using Task_project.DataAccess;

namespace Task_project.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext _DbContext = new();
        public IActionResult BookAppointment()
        {
            var data = _DbContext.Doctors;
            return View(data.ToList());
        }
        public IActionResult CompleteAppointment()
        {
            return View();
        }
        public IActionResult ReservationsManagement()
        {
            return View();
        }
    }
}
