using Business.Models.Certificate;
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

        public List<CertificateModel> CertificatePurchases { get; set; }

        public List<MoneyTransferModel> MoneyTransfersFromStudent { get; set; }

        public List<MoneyTransferModel> MoneyTransfersToStudent { get; set; }

        public List<StudentRewardModel> StudentRewards { get; set; }
    }
}