using Microsoft.AspNetCore.Mvc;

namespace Task_project.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult BookAppointment()
        {
            return View();
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
