namespace Task_project.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Appointment_Date { get; set; }
        public Reservation reservation { get; set; }

    }
}
