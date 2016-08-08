using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CampUnit
    {
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public int  UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
