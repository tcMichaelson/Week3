using ContactManagerWithGenericRepository.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManagerWithGenericRepository.Models {
    public class DataContext : DbContext {
        
        static DataContext() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());                
        }

        public IDbSet<Contact> Contacts { get; set; }

    }
}