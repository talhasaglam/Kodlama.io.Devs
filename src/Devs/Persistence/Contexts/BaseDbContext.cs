using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration _configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration): base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable(nameof(ProgrammingLanguage)).HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable(nameof(Technology)).HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(x=>x.ProgLangId).HasColumnName("ProgLangId");
                a.HasOne(x => x.ProgrammingLanguage).WithMany( x=>x.Technologies).HasForeignKey(x=>x.ProgLangId);
            });

        }

        //SaveChanges çalışmadan önce yapılan işlemleri yaptırmamızı sağlaycak.
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAlllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAlllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            //var addedEntities = ChangeTracker.Entries().Where(i => i.State == EntityState.Added).Select(i => (Entity)i.Entity);
            var allEntites = ChangeTracker.Entries();//.Select(i => (Entity)i.Entity);
            foreach (var entity in allEntites)
            {
                var baseEntity = (Entity)entity.Entity;
                switch (entity.State)
                {
                    case EntityState.Added:
                        baseEntity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        baseEntity.UpdatedDate = DateTime.Now;
                        break;
                }
            }


            //foreach (var entity in addedEntities)
            //{
            //    entity.CreatedDate = DateTime.Now;
            //}
        }
    }
}
