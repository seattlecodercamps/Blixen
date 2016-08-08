using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Troop
    {
        public int Id { get; set; }

        public int CampId { get; set; }

        public Camp Camp { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
