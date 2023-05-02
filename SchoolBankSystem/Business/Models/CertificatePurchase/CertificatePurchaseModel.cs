using Business.Models.Certificate;
using Business.Models.Student;

namespace Business.Models.CertificatePurchase
{
    public class CertificatePurchaseModel
    {
        public Guid Id { get; set; }

        public DateTime? ActivatedTime { get; set; }

        public decimal Price { get; set; }

        public Guid StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentSunrame { get; set; }

        public Guid CertificateId { get; set; }

        public CertificateModel Certificate { get; set; }

        public DateTime Time { get; set; }
    }
}