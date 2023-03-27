using PlatformService.Models;

namespace PlatformService.Data;

public static class PreDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("Seeding data");
            context.Platforms.AddRange(
                new Platform{Name = "Dotnet",Publisher="Dev",Cost = "Free"},
                            new Platform{Name = "Java",Publisher="byJava",Cost = "222"},
                            new Platform{Name = "Node",Publisher="byNode",Cost = "111"}
                );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("We already have data");
        }
    }
}