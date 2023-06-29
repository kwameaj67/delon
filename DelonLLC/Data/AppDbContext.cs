using DelonLLC.Dtos;
using DelonLLC.Model;
using Microsoft.EntityFrameworkCore;

namespace DelonLLC.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CardRequestDto> customer_cards { get; set; }
    }
}
