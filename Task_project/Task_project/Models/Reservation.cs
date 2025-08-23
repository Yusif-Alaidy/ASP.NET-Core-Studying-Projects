namespace Task_project.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient patient { get; set; }

    }
}
