using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiniNinja.Models;

namespace MiniNinja.Controllers
{
    [Authorize
        ]
    public class ValuesController : ApiController
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        // GET api/values
        public IEnumerable<IncidentVM> Get()
        {
            var data = ctx.Incidents.Include("Logs").Include("Author").ToList();
            List<IncidentVM> incidents = new List<IncidentVM>();
            foreach (Incident incident in data)
            {
                IncidentVM currentIncident = new IncidentVM();
                currentIncident.Location = incident.Location;
                currentIncident.Description = incident.Description;
                currentIncident.Active= incident.Active;
                currentIncident.TimeStamp = incident.TimeStamp;
                currentIncident.Category = incident.Category;
                currentIncident.Author = incident.Author.Email;
                currentIncident.Logs = new List<LogInIncident>();
                foreach(Log log in incident.Logs)
                {
                    currentIncident.Logs.Add(new LogInIncident { Content = log.Content, Author = log.Author.Email, TimeStamp = log.TimeStamp });
                }
                incidents.Add(currentIncident);
            }
            return incidents;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]RegisterIncident Data)
        {
            Incident incident = new Incident();
            incident.Description = Data.Description;
            incident.Location = Data.Location;
            incident.Category = Data.Category;
            incident.Active = Data.Active;
            incident.TimeStamp = DateTime.Now;
            incident.Logs = new List<Log>();

            if (!String.IsNullOrEmpty(Data.LogContent))
            {
                Log log = new Log { Content = Data.LogContent, TimeStamp = DateTime.Now, Incident = incident };
                incident.Logs.Add(log);
            }

            ctx.Incidents.Add(incident);
            ctx.SaveChanges();
            //Continue
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
