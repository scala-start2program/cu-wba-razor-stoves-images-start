using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wba.StovePalace.Data;

namespace Wba.StovePalace.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoveContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StoveContext>>()))
            {
                if (!context.Fuel.Any() && !context.Brand.Any() && !context.Stove.Any())
                {
                    context.Fuel.AddRange(
                        new Fuel { FuelName = "Hout" },
                        new Fuel { FuelName = "Pellets" },
                        new Fuel { FuelName = "Kolen" },
                        new Fuel { FuelName = "Gas" }
                        );
                    context.SaveChanges();

                    context.Brand.AddRange(
                        new Brand { BrandName = "Jotul" },
                        new Brand { BrandName = "Dovre" },
                        new Brand { BrandName = "Saey" }
                        );
                    context.SaveChanges();
                    context.Stove.AddRange(
                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 1,
                            ModelName = "SW1000",
                            Performance = 10000,
                            SalesPrice = 5000M
                        },
                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 1,
                            ModelName = "SW1200",
                            Performance = 12000,
                            SalesPrice = 6000M
                        },

                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 1,
                            ModelName = "SW1400",
                            Performance = 14000,
                            SalesPrice = 7000M
                        },
                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 2,
                            ModelName = "SP1100",
                            Performance = 11000,
                            SalesPrice = 7000M
                        },
                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 2,
                            ModelName = "SP1300",
                            Performance = 13000,
                            SalesPrice = 8000M
                        },
                        new Stove
                        {
                            BrandId = 1,
                            FuelId = 3,
                            ModelName = "Sc1500",
                            Performance = 15000,
                            SalesPrice = 7000M
                        },
                        new Stove
                        {
                            BrandId = 2,
                            FuelId = 1,
                            ModelName = "JW1100",
                            Performance = 11000,
                            SalesPrice = 7000M
                        },
                        new Stove
                        {
                            BrandId = 2,
                            FuelId = 1,
                            ModelName = "JW1500",
                            Performance = 15000,
                            SalesPrice = 9000M
                        },
                        new Stove
                        {
                            BrandId = 3,
                            FuelId = 3,
                            ModelName = "DC1000",
                            Performance = 10000,
                            SalesPrice = 4000M
                        },
                        new Stove
                        {
                            BrandId = 3,
                            FuelId = 4,
                            ModelName = "DG1000",
                            Performance = 10000,
                            SalesPrice = 4000M
                        }
                    );
                    context.SaveChanges();

                }



            }
        }

    }
}
