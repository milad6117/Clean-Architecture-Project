using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Service.Bases
{
    public class BaseItemDTO : BaseEntityDTO, IDateDTO
    {
        public string CreateON { get; set; }
        public string? UpdateON { get; set; }
        public DateTime LocalCreate { get; set; }
        public DateTime? LocalUpdate { get; set; }
    }
}
