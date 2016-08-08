using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class Content
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
