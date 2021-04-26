using CityDex.Models;
using Microsoft.EntityFrameworkCore;

namespace CityDex.Data{
    public class CityDexContext : DbContext{
        public DbSet<City> Ciudades { get; set; }

        public CityDexContext(DbContextOptions dco) : base(dco){}
    }
}