namespace DAL.Entities
{
    public class File
    {
        public Guid Id { get; set; }

        public string Extension { get; set; }

        public byte[] Content { get; set; }

        public List<Student> Students { get; set; }
    }
}
