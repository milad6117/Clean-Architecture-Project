using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Extension;

namespace Trial.Data.Context
{
    public class SqlServerApplicationContext : DbContext, IApplicationContext
    {
        public SqlServerApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.CreateON();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                CleanContext();
                throw ex;
            }
        }

        private void CleanContext()
        {
            if (this.ChangeTracker.HasChanges())
            {
                var _list = this.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted).ToList();
                foreach (var item in _list)
                {
                    item.State = EntityState.Unchanged;
                }
            }
        }
    }
}
