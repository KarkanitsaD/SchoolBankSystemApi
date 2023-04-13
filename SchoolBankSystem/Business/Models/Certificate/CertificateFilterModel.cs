namespace Business.Models.Certificate
{
    public class CertificateFilterModel
    {
        public string? Title { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set;}
    }
}
