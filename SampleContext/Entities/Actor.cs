using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleContext.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }


        public ICollection<Casting> Castings { get; set; }
    }
}