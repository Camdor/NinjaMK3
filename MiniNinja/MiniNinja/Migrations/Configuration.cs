namespace MiniNinja.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MiniNinja.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniNinja.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniNinja.Models.ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = "kt.keijser@gmail.com", Email = "kt.keijser@gmail.com", Incidents = new List<Incident>(), Logs = new List<Log>() };
            var incident = new Incident { Active = false, Author = user, Category = IncidentCategory.Some, Description = "Panda unable to walk", Location = "South/Solo", TimeStamp = DateTime.Now.AddHours(-1), Logs = new List<Log>() };
            var log1 = new Log { Author = user, Content = "Went to solo, escorting the person to the infermary", Incident = incident, TimeStamp = DateTime.Now.AddMinutes(-45) };
            var log2 = new Log { Author = user, Content = "Let the person rest while magically healing his/her foot", Incident = incident, TimeStamp = DateTime.Now.AddMinutes(-30) };

            incident.Logs.Add(log1);
            incident.Logs.Add(log2);

            user.Incidents.Add(incident);
            user.Logs.Add(log1);
            user.Logs.Add(log2);

            manager.Create(user, "Passw0rd!");
            context.SaveChanges();
        }
    }
}
