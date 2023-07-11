using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Domain;

namespace Trial.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Configuration

            //! EF Configuration

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.CustomerNumber).IsRequired();
            builder.Property(p => p.FathersName).IsRequired();
            builder.Property(p => p.BirthCertificate).IsRequired();
            builder.Property(p => p.NationalCode).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Ignore(p => p.FullName);
            
            #endregion
        }
    }
}
