using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GestaoProdutos.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Codigo") != null))
            {
                //if (entry.State == EntityState.Added)
                //{
                //    entry.Property("DataFabricacao").CurrentValue = DateTime.Now;
                //}

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Codigo").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}