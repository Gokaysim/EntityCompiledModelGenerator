using Microsoft.EntityFrameworkCore;
using SampleContext.Entities;

namespace SampleContext
{
    public class SampleContext:DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Casting> Casting { get; set; }
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var actorEntity = modelBuilder.Entity<Actor>();
            actorEntity.HasKey(p => p.ActorId);                                 
            
            var movieEntity = modelBuilder.Entity<Movie>();
            movieEntity.HasKey(p => p.MovieId);
            
            var castingEntity = modelBuilder.Entity<Casting>();
            castingEntity.HasKey(p => p.CastingId);
            castingEntity.HasOne(p => p.Actor)
                .WithMany(p => p.Castings)
                .HasForeignKey(p => p.ActorId);
            castingEntity.HasOne(p => p.Movie)
                .WithMany(p => p.Castings)
                .HasForeignKey(p => p.MovieId);


        }
    }
}