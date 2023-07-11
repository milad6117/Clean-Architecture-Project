using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Entities;

namespace Trial.Core.Domain
{
    public class Customer:BaseEntity
    {
        #region Properties
        public string CustomerNumber { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get => Name + " " + LastName;
        }

        public string FathersName { get; set; }

        public string BirthCertificate { get; set; }

        public string NationalCode { get; set; }

        public string DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        #endregion
    }
}
