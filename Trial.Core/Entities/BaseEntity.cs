using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Core.Entities
{
    public class BaseEntity:Entity,IDateEntity
    {
        public int ID { get; set; }
        public DateTime CreateON { get; set; } = DateTime.Now;
        public DateTime? UpdateON { get; set; }
    }
}
