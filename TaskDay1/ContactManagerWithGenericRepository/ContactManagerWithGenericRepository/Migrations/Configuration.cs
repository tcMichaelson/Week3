namespace ContactManagerWithGenericRepository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using Models;
    using System.Net;
    using Newtonsoft.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManagerWithGenericRepository.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactManagerWithGenericRepository.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //string[] nameList = File.ReadAllLines(@"~\Content\NameList.txt");

            WebRequest req = WebRequest.CreateHttp("http://randomuser.me/api?results=100");
            var response = req.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();

            for (var i = 0; i<100; i++ ) {
                Contact newContact = new Contact();
                dynamic json = JsonConvert.DeserializeObject(result);
                var baseDate = new DateTime(1970, 1, 1,0,0,0,DateTimeKind.Utc);
                long secondsToAdd = long.Parse((string)json.results[i].user.dob);
                var newDate = baseDate.AddSeconds(secondsToAdd);

                newContact.FirstName = json.results[i].user.name.first;
                newContact.LastName = json.results[i].user.name.last;
                newContact.PhoneNumber = json.results[i].user.phone;
                newContact.Birthday = newDate;
                context.Contacts.AddOrUpdate(
                    m => new { m.FirstName, m.LastName, m.Birthday, m.PhoneNumber},
                    newContact);
                context.SaveChanges();
            }
        }
        
    }
}
