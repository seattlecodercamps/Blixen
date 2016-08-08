using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TroopViewModel
    {
        public int Id { get; set; }

        public string CampName { get; set; }

        public DateTime StartDate { get; set; }
    }
}
