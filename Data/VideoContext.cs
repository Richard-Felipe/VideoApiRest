using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public VideoContext(DbContextOptions<VideoContext> options) : base(options) { }
    }
}
