using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiveService.API.Controllers;
using HiveService.API.Domain;
using HiveService.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HiveService.Tests
{
    public class HiveControllerTests
    {
        private HiveDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<HiveDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new HiveDbContext(options);
        }

        [Fact]
        public async Task GetHives_Filters_By_Status()
        {
            using var context = CreateContext();
            context.Hives.AddRange(
                new Hive { HiveId = Guid.NewGuid(), HiveName = "A", HealthStatus = "good" },
                new Hive { HiveId = Guid.NewGuid(), HiveName = "B", HealthStatus = "critical" }
            );
            await context.SaveChangesAsync();

            var controller = new HiveController(context);
            var result = await controller.GetHives("good");

            var hives = Assert.IsType<List<Hive>>(result.Value);
            Assert.Single(hives);
            Assert.Equal("good", hives.First().HealthStatus);
        }
    }
}
