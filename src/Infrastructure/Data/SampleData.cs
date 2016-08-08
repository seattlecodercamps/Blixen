using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Data
{
    public class SampleData
    {
        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // if db is empty of camps...
            if (!db.Camps.Any())
            {

                // add students
                await EnsureUser(userManager, new Student { UserName = "Stephen", Email = "Stephen.Walther@CoderCamps.com" });
                await EnsureUser(userManager, new Student { UserName = "Nick", Email = "Nick@CoderCamps.com" });
                await EnsureUser(userManager, new Student { UserName = "Dan", Email = "Dan@CoderCamps.com" });


                // add camps
                db.Camps.AddRange(
                    new Camp {
                        BriefName = "FSNET",
                        Name = "Fullstack .NET+JS"
                    },
                    new Camp {
                        BriefName = "FSJS",
                        Name = "Fullstack JS"
                    }
                );

                db.SaveChanges();


                // add units
                db.Units.AddRange(
                    CreateSourceControlUnit(),
                    CreateIntroASPNETUnit(),
                    CreateIntroNodeUnit()
                );
                db.SaveChanges();

                // associate units with camps (many-to-many)
                db.CampUnits.AddRange(
                    new CampUnit {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSNET").Id,
                        UnitId = db.Units.FirstOrDefault(c => c.Title == "Source Control").Id  
                    },
                    new CampUnit
                    {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSJS").Id,
                        UnitId = db.Units.FirstOrDefault(c => c.Title == "Source Control").Id
                    },
                    new CampUnit
                    {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSNET").Id,
                        UnitId = db.Units.FirstOrDefault(c => c.Title == "Intro to ASP.NET").Id
                    },
                    new CampUnit
                    {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSJS").Id,
                        UnitId = db.Units.FirstOrDefault(c => c.Title == "Intro to NodeJS").Id
                    }
                );

                db.SaveChanges();



                // add troops
                db.Troops.AddRange(
                    new Troop
                    {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSNET").Id,
                        Students = new List<Student>
                        {
                            db.Students.First(s => s.UserName == "Stephen"),
                            db.Students.First(s => s.UserName == "Nick")

                        }
                    },
                    new Troop
                    {
                        CampId = db.Camps.FirstOrDefault(c => c.BriefName == "FSJS").Id,
                        Students = new List<Student>
                        {
                            db.Students.First(s => s.UserName == "Stephen"),
                            db.Students.First(s => s.UserName == "Dan")

                        }
                    }
                );

                db.SaveChanges();


            }
        }

        private async static Task EnsureUser(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            var original = await userManager.FindByNameAsync(user.UserName);
            if (original == null)
            {
                var result = await userManager.CreateAsync(user, "Secret123!");
            }
        }

        private static Unit CreateSourceControlUnit()
        {
            return new Unit
            {
                Title = "Source Control",
                Modules = new Module[] {
                    new Module
                    {
                        Title = "Introduction to Github",
                        Content = new Content[]
                        {
                            new ContentLesson
                            {
                                Title = "Installing Git",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "go to git-scm.org"
                                    }
                                }
                            },
                            new ContentLesson
                            {
                                Title = "Registering at GitHub",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "Registering at GitHub."
                                    }
                                }
                            }

                        }
                    }
                }
            };
        }


        private static Unit CreateIntroASPNETUnit()
        {
            return new Unit
            {
                Title = "Intro to ASP.NET",
                Modules = new Module[] {
                    new Module
                    {
                        Title = "Installing ASP.NET Software Prereqs",
                        Content = new Content[]
                        {
                            new ContentLesson
                            {
                                Title = "Installing Windows",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "You should install windows"
                                    }
                                }
                            },
                            new ContentLesson
                            {
                                Title = "Installing Visual Studio",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "Installing vs is easy."
                                    }
                                }
                            }

                        }
                    }
                }
            };

        }

        public static Unit CreateIntroNodeUnit()
        {
            return new Unit
            {
                Title = "Intro to NodeJS",
                Modules = new Module[] {
                    new Module
                    {
                        Title = "Installing NodeJS Software Prereqs",
                        Content = new Content[]
                        {
                            new ContentLesson
                            {
                                Title = "Installing NodeJS",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "Nodejs is everything on the server."
                                    }
                                }
                            },
                            new ContentLesson
                            {
                                Title = "Installing NPM",
                                LessonFlavors = new ContentLessonFlavor[]
                                {
                                    new ContentLessonFlavor
                                    {
                                        Text = "Installing NPM is easy."
                                    }
                                }
                            }

                        }
                    }
                }
            };

        }



    }
}

    


  
