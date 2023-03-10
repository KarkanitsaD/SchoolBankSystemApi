namespace Business.Models.Student
{
    public class StudentFilterModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public decimal? MinSum { get; set; }

        public decimal? MaxSum { get; set; }
    }
}