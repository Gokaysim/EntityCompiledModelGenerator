namespace SampleContext.Entities
{
    public class Casting
    {
        public int CastingId { get; set; }

        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}