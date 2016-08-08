using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Services;
using Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Blixen.Api
{
    [Route("api/[controller]")]
    public class TroopController : Controller
    {
        private TroopService troopService;

        // GET: api/values
        [HttpGet("{id?}")]
        public IList<TroopViewModel> Get()
        {
            return troopService.ListTroops(this.User);
        }

        public TroopController(TroopService troopService)
        {
            this.troopService = troopService;
        }

    }
}
