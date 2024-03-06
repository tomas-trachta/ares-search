using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresSearchAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=AresSearchDb;Integrated Security=SSPI;MultipleActiveResultSets=False;TrustServerCertificate=True;Connection Timeout=30;");
        }

        public DbSet<CompanyInformationModel> CompanyInformation { get; set; }
    }
}
