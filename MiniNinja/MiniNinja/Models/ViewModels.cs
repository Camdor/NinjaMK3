using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniNinja.Models
{
    public class RegisterIncident
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public IncidentCategory Category { get; set; }
        public string LogContent { get; set; }
    }
    public class LogInIncident
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class IncidentVM
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime TimeStamp { get; set; }
        public IncidentCategory Category { get; set; }
        public string Author { get; set; }
        public List<LogInIncident> Logs { get; set; }
    }

}