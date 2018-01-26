using Microsoft.EntityFrameworkCore;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Entities.Interfaces;
using System;
using System.Linq;

namespace Infrastructure.Data
{
    public class ShareFlowContext : DbContext
    {
        public ShareFlowContext(DbContextOptions<ShareFlowContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override int SaveChanges()
        {
            var lTimestampableEntities = ChangeTracker.Entries<ITimestampable>()
                .Select(e => e.Entity)
                .ToArray();

            foreach (var lEntity in lTimestampableEntities)
            {
                lEntity.OperationDate = DateTime.UtcNow;
            }

            int result = base.SaveChanges();

            return result;
        }
    }
}