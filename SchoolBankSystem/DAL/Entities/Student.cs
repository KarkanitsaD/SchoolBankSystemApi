namespace DAL.Entities;

public class Student : User
{
    public List<CertificatePurchase> CertificatePurchases { get; set; }

    public List<StudentReward> StudentRewards { get; set; }

    public List<MoneyTransfer> MoneyTransfersFromStudent { get; set; }

    public List<MoneyTransfer> MoneyTransfersToStudent { get; set; }
}