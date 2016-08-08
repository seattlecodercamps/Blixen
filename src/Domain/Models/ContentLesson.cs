using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContentLesson : Content
    {
        public ICollection<ContentLessonFlavor> LessonFlavors { get; set; }
    }
}
