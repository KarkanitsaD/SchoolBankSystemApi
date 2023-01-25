namespace DAL.Entities;

public class CertificatePurchase : Transaction
{
    public Guid Id { get; set; }

    public DateTime? ActivatedTime { get; set; }

    public decimal Price { get; set; }

    public Guid StudentId { get; set; }

    public Student Student { get; set; }

    public Guid CertificateId { get; set; }

    public Certificate Certificate { get; set; }
}