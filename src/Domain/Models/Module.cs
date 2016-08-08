using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Module
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Content> Content { get; set; }
    }
}
