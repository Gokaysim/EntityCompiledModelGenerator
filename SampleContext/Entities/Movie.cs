using System.Collections.Generic;

namespace SampleContext.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public double AveragePoints { get; set; }
        
        public ICollection<Casting> Castings { get; set; }
    }
}