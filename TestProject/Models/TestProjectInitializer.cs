using System.Collections.Generic;
using System.Data.Entity;

namespace TestProject.Models
{
    public class TestProjectInitializer : DropCreateDatabaseAlways<TestProjectContext>
    {
        // JEMO : enabled as the initializer for the TestProjectContext in the Application_Start() event of the Global.asax

        // JEMO : this is a initializer class that overrides the default model-to-database creation and always (re)creates my database. 
        // with this initializer i can manipulate the behavior of the creation event whenever i (re)create my database and, like i am going to do, 
        // create seed data in the database upon creation. 

        // JEMO_CAUTION : this Initializer will actually destroy the existing database and with it the existing data. This Initialiser should never be used in production environments
        // but for now it suits my test situation.

        // JEMO_STUDY : look into CreateDatabaseIfNotExists<T> for possibly a safer approach and study the Migration feature of the Entity Framework. it is also possible to 
        // set the DB initializer from the *.config file, but i first need to study how unit testing works before i can determine the usabillity of this option



        // JEMO : i want to populate my database with some seed data on creation in order to prevent having to mannually add them or supplying a pre-populated database with the project
        // which basically defeats the purpose of the Code-first application build methodology.
        protected override void Seed(TestProjectContext context)
        {
            base.Seed(context);
            // JEMO : not sure how to interpret this line, but i think this overrides/sets the DBContext which the overridden Seed method uses to create the database seed data.
            // JEMO_QUESTION : ask StackOverflow how to interpret base.Seed(context)


            // JEMO : preset the images url for easy usage
            var imagelocationUrl = "~/Content/Images/";

            // JEMO : create a list of Picture seeddata to add to the TestProject.Pictures database table
            var pictures = new List<Picture>{
                new Picture{Name = "brain-hands.jpg", Url = (imagelocationUrl + "brain-hands.jpg")},
                new Picture{Name = "earth.jpg", Url = (imagelocationUrl + "earth.jpg")},
                new Picture{Name = "FireRain.jpg", Url = (imagelocationUrl + "FireRain.jpg")},
                new Picture{Name = "Lazy_Squirrel.jpg", Url = (imagelocationUrl + "Lazy_Squirrel.jpg")},
                new Picture{Name = "lightbulb-experiment.jpg", Url = (imagelocationUrl + "lightbulb-experiment.jpg")},
                new Picture{Name = "lovebirds.jpg", Url = (imagelocationUrl + "lovebirds.jpg")},
                new Picture{Name = "picture-in-picture.jpg", Url = (imagelocationUrl + "picture-in-picture.jpg")},
                new Picture{Name = "smiley-wink.jpg", Url = (imagelocationUrl + "smiley-wink.jpg")},
                new Picture{Name = "Colourfull-wings.jpg", Url = (imagelocationUrl + "Colourfull-wings.jpg")},
                new Picture{Name = "spaceship-entering-atmosphere.jpg", Url = (imagelocationUrl + "spaceship-entering-atmosphere.jpg")}
            };

            // JEMO : loop trough the list of new pictures and add them to the Pictures within the database context
            foreach (var pic in pictures)
            {
                context.Pictures.Add(pic);
            }

            // JEMO : save the changes made to the database context so the database build event will add these records to the TestProject.Pictures table
            context.SaveChanges();



        }

    }
}