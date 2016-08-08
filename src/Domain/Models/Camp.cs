using System;
using System.Collections.Generic;
namespace Domain.Models
{

    public class Camp
    {
        public int Id { get; set; }

        public string BriefName { get; set; }

        public string Name { get; set; }


        public ICollection<CampUnit> CampUnits { get; set; }

        public ICollection<Troop> Troops { get; set; }

    }

}