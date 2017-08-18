using System;
using System.Collections.Generic;
using System.Linq;


namespace MiniNinja.Models
{
    public class Incident
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime TimeStamp { get; set; }
        public IncidentCategory Category { get; set; }
        public ApplicationUser Author { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
    public class Log
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public ApplicationUser Author { get; set; }
        public virtual Incident Incident { get; set; }

    }
    public enum IncidentCategory
    {
        Some,
        Body,
        Once,
        Told,
        Me,
        The,
        World,
        Was,
        Gonna,
        Roll,
    }
}