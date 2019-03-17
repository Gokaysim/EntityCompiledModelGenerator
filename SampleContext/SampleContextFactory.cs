using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace SampleContext
{
    public class SampleContextFactory:IDesignTimeDbContextFactory<SampleContext>

    {
        public SampleContext CreateDbContext(string[] args)
        { 
            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();

            optionsBuilder.UseSqlite("Data Source=blogging.db");

            return new SampleContext(optionsBuilder.Options);
        }
    }
}