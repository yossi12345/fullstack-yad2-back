using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using yad2_back.Models;

namespace yad2_back.Data
{
    public class Yad2Context:IdentityDbContext<UserModel>
    {
        public Yad2Context(DbContextOptions<Yad2Context> options) : base(options) { }
        public DbSet<ApartmentModel> Apartments { get; set; }
        public DbSet<FeatureModel> Features { get; set; }
        public DbSet<ApartmentTypeModel> Types {  get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserModel>().HasMany(u => u.ApartmentForSelling).WithOne(a => a.Advertiser);
            builder.Entity<UserModel>().HasMany(u => u.FavoriteApartments);
        }
    }
}
