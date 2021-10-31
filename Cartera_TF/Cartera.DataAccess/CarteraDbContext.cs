using Cartera.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cartera.DataAccess
{
    public class CarteraDbContext :DbContext
    {
        public CarteraDbContext(DbContextOptions<CarteraDbContext> options)
       : base(options)
        {

        }

        public CarteraDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-44K5N6D\MSSQLSERVER2;Database=CarteraDb;Integrated Security=true;");

        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Type_Interest_Rate> Type_Interest_Rates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GastosFinales> GastosFinaless { get; set; }
        public DbSet<GastosIniciales> GastosInicialess { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}

