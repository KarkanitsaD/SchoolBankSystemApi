namespace DAL.Entities;

public class Certificate : CreateUpdateTimeEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public List<CertificatePurchase> CertificatePurchases { get; set; }
}