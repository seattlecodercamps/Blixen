using Domain.Models;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests.Services
{
    public class TroopServiceTests
    {
        /// <summary>
        /// Tests that only the troops for the current user are returned.
        /// </summary>
        [Fact]
        public void TestListTroops()
        {
            // arrange
            var mockRepo = new Mock<IGenericRepository>();
            mockRepo.Setup(r => r.Query<Troop>()).Returns(new List<Troop>
            {
                new Troop {
                    Id =1,
                    Students = new List<Student> {
                        new Student { UserName="Alice" },
                        new Student { UserName="Nick" }
                    }
                },
                new Troop {
                    Id =2,
                    Students = new List<Student> {
                        new Student { UserName="Alice" }
                    }
                },
                new Troop {
                    Id =3,
                    Students = new List<Student> {
                        new Student { UserName="Nick" }
                    }
                }
            }.AsQueryable());

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(p => p.Identity.Name).Returns("Nick");

            // act
            var service = new TroopService(mockRepo.Object);
            var results = service.ListTroops(mockPrincipal.Object);

            // assert
            Assert.Equal(2, results.Count());
        }
    }
}
