using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<CampUnit> CampUnits { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}
