namespace Task_project.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Img { get; set; }

        public Reservation reservation{ get; set; }
    }

}
