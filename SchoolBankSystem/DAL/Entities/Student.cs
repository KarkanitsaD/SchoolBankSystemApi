namespace DAL.Entities;

public class Student : User
{
    public decimal Sum { get; set; }

    public Guid? ClassId { get; set; }

    public Class? Class { get; set; }

    public Guid? ImageId { get; set; }

    public File? Image { get; set; }

    public List<CertificatePurchase> CertificatePurchases { get; set; }

    public List<StudentReward> StudentRewards { get; set; }

    public List<MoneyTransfer> MoneyTransfersFromStudent { get; set; }

    public List<MoneyTransfer> MoneyTransfersToStudent { get; set; }
}