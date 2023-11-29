using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
namespace TP3.Models
{
    public class TP3Context : DbContext
    {
        public TP3Context(DbContextOptions<TP3Context> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres {  get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //Deserializer Json en objets 
            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("wwwroot/Genres.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>()
                .HasData(c);

        }
    }
}
