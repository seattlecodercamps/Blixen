using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ContentViewModel> Content { get; set; }
    }
}
