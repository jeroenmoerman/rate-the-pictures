using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestProject.Models
{
    public class TestProjectContext : DbContext
    {
        // JEMO : since the application is written using the code-first technique we are not going to create a database beforehand. but in order to be able to write code as if it does exists
        // the application needs a DbContext of the database. the DbContext is a reflection of how the database must look like and behave when we create it trough the entity framework.
        // so in other words: we can PROGRAM IN THE CONTEXT OF THE DATABASE even tough it does not exists.


        #region Table defenitions


        // JEMO : Determine the Tables to create for our entities we want when our context is used to create the actuall database from
        public DbSet<Picturerating> Pictureratings { get; set; }
        public DbSet<Picture> Pictures { get; set; }


        #endregion


        // JEMO : Prevent the Entity Framework from using plural tablenames for the Entity models. this is by my own preference since my tables are meant to keep multiple records,
        // each containing information about one item instead of multiple items.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }



        // JEMO : expose the Database.ExecuteSqlCommand(sql) in order to be able to write SQL next to talking to the database trough the entity framework.
        public int ExecuteSqlCommand(string sql)
        {
            // JEMO : raw sql is very powerful for when you need to interact with the database or the tables itself. it's also very dangerous so use with caution at all times.
            // MSSQL, like many other SQL database engines come with many great build in features like stored procedures, triggers and analysis functions that help maintain and optimise the
            // database and Production environment.
            return base.Database.ExecuteSqlCommand(sql);
        }

    }
}