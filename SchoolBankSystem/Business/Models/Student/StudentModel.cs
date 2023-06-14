using Business.Models.CertificatePurchase;
using Business.Models.Class;
using Business.Models.MoneyTransfer;
using Business.Models.StudentReward;

namespace Business.Models.Student
{
    public class StudentModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public decimal Sum { get; set; }

        public Guid? ImageId { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageExtension { get; set; }

        public Guid? ClassId { get; set; }

        public ClassModel? Class { get; set; }

        public List<CertificatePurchaseModel>? CertificatePurchases { get; set; }

        public List<MoneyTransferModel>? MoneyTransfersFromStudent { get; set; }

        public List<MoneyTransferModel>? MoneyTransfersToStudent { get; set; }

        public List<MoneyTransferModel>? MoneyTransfers { get; set; }

        public List<StudentRewardModel>? StudentRewards { get; set; }
    }
}