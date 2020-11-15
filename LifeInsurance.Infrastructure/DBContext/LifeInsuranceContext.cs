using LifeInsurance.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeInsurance.Infrastructure.DBContext
{
    public class LifeInsuranceContext : DbContext
    {
        public LifeInsuranceContext(DbContextOptions<LifeInsuranceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasKey(p=>p.ContractId);
        }
        public virtual DbSet<Contract> Contracts { get; set; }
    }
}
