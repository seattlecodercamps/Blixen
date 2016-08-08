using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ModuleViewModel> Modules { get; set; }
    }
}
