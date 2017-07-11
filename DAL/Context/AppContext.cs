using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppContext : DbContext
    {

        public DbSet<SelectedCity> SelectedCities { get; set; }
        public DbSet<HistoryModel> History { get; set; }
        public static object ConfigurationManager { get; private set; }

        public AppContext(string connectionString)
            : base(connectionString)
        {

        }
       
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
{
    protected override void Seed(AppContext db)
    {
            db.SelectedCities.Add(new SelectedCity { Name = "Kiev" });
            db.SelectedCities.Add(new SelectedCity { Name = "Lviv" });
            db.SelectedCities.Add(new SelectedCity { Name = "Kharkiv" });
            db.SelectedCities.Add(new SelectedCity { Name = "Dnipropetrovsk" });
            db.SelectedCities.Add(new SelectedCity { Name = "Odessa" });

            db.SaveChanges();
    }
}
}
