using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.ViewModels;
using System.Security.Claims;
using Domain.Models;
using System.Security.Principal;

namespace Domain.Services
{
    public class TroopService
    {
        private IGenericRepository repo;



        public IList<TroopViewModel> ListTroops(IPrincipal user)
        {
            return repo.Query<Troop>()
                .Where(t => t.Students.Any(s => s.UserName == user.Identity.Name))
                .Select(t => new TroopViewModel {
                    Id = t.Id,
                    CampName = t.Camp.Name,
                    StartDate = t.StartDate
                })
                .ToList();
        }

        public CampViewModel GetCamp(int id)
        {
            var camp = this.repo.Query<Camp>().Where(c => c.Id == id).Select(
                c => new CampViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Units = c.CampUnits.Select(u => new UnitViewModel
                    {
                        Id = u.Unit.Id,
                        Title = u.Unit.Title,
                        Modules = u.Unit.Modules.Select(m => new ModuleViewModel
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Content = m.Content.Select(content => new ContentViewModel
                            {
                                Id = content.Id,
                                Title = content.Title
                            }).ToList()
                        }).ToList()
                    }).ToList()

                }
            ).FirstOrDefault();

            return camp;
        }


        public TroopService(IGenericRepository repo)
        {
            this.repo = repo;
        }
    }
}
