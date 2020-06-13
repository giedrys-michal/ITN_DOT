using Apteczka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Apteczka.Data_Access
{
    public class ApteczkaContext : DbContext
    {
        public ApteczkaContext() : base("ApteczkaContext") { }

        public DbSet<LekModel> LekiDB { get; set; }
        public DbSet<ApteczkaModel> ApteczkiDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}