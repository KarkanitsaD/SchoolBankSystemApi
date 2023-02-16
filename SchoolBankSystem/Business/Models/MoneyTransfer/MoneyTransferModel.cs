using Business.Models.Student;

namespace Business.Models.MoneyTransfer
{
    public class MoneyTransferModel
    {
        public Guid Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Sum { get; set; }

        public Guid StudentFromId { get; set; }

        public StudentModel StudentFrom { get; set; }

        public Guid StudentToId { get; set; }

        public StudentModel StudentTo { get; set; }
    }
}