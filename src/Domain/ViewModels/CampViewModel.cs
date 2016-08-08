using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CampViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UnitViewModel> Units { get; set; }
    }
}
