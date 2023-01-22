namespace DAL.Entities;

public class MoneyTransfer : Transaction
{
    public Guid Id { get; set; }

    public decimal Sum { get; set; }

    public Guid StudentFromId { get; set; }

    public Student StudentFrom { get; set; }

    public Guid StudentToId { get; set; }

    public Student StudentTo { get; set; }
}