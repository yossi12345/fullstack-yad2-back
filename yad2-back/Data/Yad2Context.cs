using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using yad2_back.Models;

namespace yad2_back.Data
{
    public class Yad2Context:IdentityDbContext<UserModel>
    {
        public Yad2Context(DbContextOptions<Yad2Context> options) : base(options) { }
    }
}
