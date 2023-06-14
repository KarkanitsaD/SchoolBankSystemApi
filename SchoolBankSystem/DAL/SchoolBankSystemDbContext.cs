using DAL.Entities;
using DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using File = DAL.Entities.File;

namespace DAL;

public class SchoolBankSystemDbContext : DbContext
{
    public DbSet<Certificate> Certificates { get; set; }

    public DbSet<CertificatePurchase> CertificatePurchases { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<MoneyTransfer> MoneyTransfer { get; set; }

    public DbSet<Reward> Rewards { get; set; }

    public DbSet<StudentReward> StudentsRewards { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<File> Files { get; set; }

    public SchoolBankSystemDbContext(DbContextOptions<SchoolBankSystemDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new CertificateConfiguration())
            .ApplyConfiguration(new CertificatePurchaseConfiguration())
            .ApplyConfiguration(new StudentConfiguration())
            .ApplyConfiguration(new MoneyTransferConfiguration())
            .ApplyConfiguration(new RewardConfiguration())
            .ApplyConfiguration(new StudentRewardConfiguration())
            .ApplyConfiguration(new TeacherConfiguration())
            .ApplyConfiguration(new ClassConfiguration())
            .ApplyConfiguration(new FileConfiguration())
            ;
    }
}