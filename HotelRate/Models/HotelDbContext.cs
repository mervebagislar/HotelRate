using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelRate2.Models;

public partial class HotelDbContext : DbContext
{
    

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public DbSet<Kullanicilar> Kullanicilar => Set<Kullanicilar>();
    public DbSet<Otel> Oteller => Set<Otel>();

    public DbSet<Soru> Sorular => Set<Soru>();

    public DbSet<Cevap> Cevaplar => Set<Cevap>();

    public DbSet<OtelResim> Resimler => Set<OtelResim>();


    
    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (Exception ex)
        {
           
            throw;
        }
    }
}
