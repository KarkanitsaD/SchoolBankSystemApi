namespace Business.Models.Auth
{
    public class RegisterModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageExtension { get; set; }
    }
}