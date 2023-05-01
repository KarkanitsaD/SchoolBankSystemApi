namespace Business.Models.MoneyTransfer
{
    public class MoneyTransferModel
    {
        public Guid Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Sum { get; set; }

        public Guid StudentFromId { get; set; }

        public string StudentFromName { get; set; }

        public string StudentFromSurname { get; set; }

        public Guid StudentToId { get; set; }

        public string StudentToName { get; set; }

        public string StudentToSurname { get; set; }
    }
}