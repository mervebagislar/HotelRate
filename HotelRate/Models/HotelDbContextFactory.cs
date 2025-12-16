using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelRate2.Models;

public class HotelDbContextFactory
    : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=HotelRateDB;Trusted_Connection=True;TrustServerCertificate=True"
        );

        return new HotelDbContext(optionsBuilder.Options);
    }
}
