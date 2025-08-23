using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_project.DataAccess;
using Task_project.Models;
using Task_project.ViewModel;

namespace Task_project.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext _DbContext = new();
        public IActionResult BookAppointment(DoctorVM doctorVM, int page = 1)
        { 

            var doctors = _DbContext.Doctors.AsQueryable();

            // filter name
            if (doctorVM.Name is not null)
            {
                doctors = doctors.Where(e => e.Name.Contains(doctorVM.Name));
                ViewBag.DoctorName = doctorVM.Name;
            }

            // filter Spacialization
            if (doctorVM.Spacialization is not null)
            {
                doctors = doctors.Where(e => e.Specialization.Contains(doctorVM.Spacialization));
                ViewBag.DoctorSpacialization = doctorVM.Spacialization;

            }


            var totalNumberOfPages = Math.Ceiling(doctors.Count() / 8.0);
            var currentPage = page;
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.currentPage = currentPage;

            doctors = doctors.Skip((page - 1) * 8).Take(8);

            return View(doctors.ToList());
        }

        [HttpGet]
        public IActionResult CompleteAppointment(int id, string patientName, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            var fullDateTime = appointmentDate.Date + appointmentTime;
            var _patient = _DbContext.patients.FirstOrDefault(p => p.Name == patientName);
            if (_patient == null)
            {
                return NotFound();
            }

            var _doctor = _DbContext.Doctors.FirstOrDefault(p => p.Id == id);
            if (_doctor == null) 
            {
                return NotFound();
            }

            var res = new Reservation
            {
                DateTime = fullDateTime,
                PatientId = _patient.Id,
                DoctorId = _doctor.Id

            };
            _DbContext.reservations.Add(res);
            _DbContext.SaveChanges();

            return Redirect("Index");
        }
        public IActionResult ReservationsManagement()
        {
            return View();
        }
    }
}
