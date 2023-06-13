namespace DAL.Entities
{
    public class Class
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
