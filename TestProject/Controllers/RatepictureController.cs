using System.Linq;
using System.Web.Mvc;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    public class RatepictureController : Controller
    {

        #region Setup

        // JEMO : declare the database context so it can be used in this controller
        private TestProjectContext db = new TestProjectContext();


        #endregion



        #region Request Action methods


        public ActionResult Index(int? requestedPictureID) // JEMO : default request action with a optional parameter for the pictureID the user requests
        {
            // JEMO : in order to make sure the results we get from the database are only the results after each full picture ratings round we are going to clear our Picturerating table.
            DeleteAllPictureratings();

            // JEMO : determine if the request came with a requestedPictureID. if so, use it. otherwise start the page with the default picture (in this tests case, picture with ID 1)
            int pictureID = (requestedPictureID == null ? 1 : requestedPictureID.GetValueOrDefault());

            // JEMO :  supply the viewModel to the View so it can be used in the View that we will return to the user, and simultaneously return the view
            return View(CreatePictureratingViewModel(pictureID));
        }


        [HttpPost] // JEMO : defines the request method as a Post method
        [ValidateAntiForgeryToken] // JEMO : checks if the AntiForgeryToken provided in the posted form Matches with our auto-generated token in order to prevent Cross site Request Forgery attacks, or CRF-attacks
        public PartialViewResult RatePicture(int pictureID, int PictureRating) // JEMO : request action that handles a Post request with the picturerating
        {

            // JEMO : check if values of the picturerating are correct
            if (pictureID > 0 && (PictureRating > 0 && PictureRating < 11))
            {
                InsertPicturerating(pictureID, PictureRating);

                if (pictureID != 10)
                {
                    // JEMO : increment the pictureID and create the PictureratingViewModel with the updated ID, and return the next partial picture form to be rated by the user
                    return PartialView("_PicturerateFormPartial", CreatePictureratingViewModel(++pictureID).Picture);
                }
                else
                {
                    // JEMO
                    return PartialView("_PicturerateDonePartial");
                }
            }
            else
            {
                return PartialView("_ErrorPartial"); // JEMO : temp solution
            }
        }


        #endregion



        #region Handler methods


        private PictureratingViewModel CreatePictureratingViewModel(int requestedPictureID)
        {
            return new PictureratingViewModel { Picture = db.Pictures.First(i => i.ID == requestedPictureID) };
        }


        #endregion




        #region CRUD methods


        private bool InsertPicturerating(int pictureID, int pictureRating)
        {

            // add the picturerating to the db and update the changes
            db.Pictureratings.Add(new Picturerating { PictureID = pictureID, Rating = pictureRating });
            db.SaveChanges();


            // return the succes of the insert action

            return true; // JEMO_TEMP : temp solution to avoid broken method
        }

        private int DeleteAllPictureratings()
        {
            // JEMO : i wanted to delete all the Pictureratings. a conventional way of doing this (since EF 6) is to remove a range by using 
            //  Model.RemoveRange method supplied with a list containing all the pictureratings like so:

            //db.Pictureratings.RemoveRange(db.Pictureratings.ToList());
            //db.SaveChanges();

            // the problem is that this way of deletion is first fetching all the pictureratings, then looping trough them all and only then deleting them.
            // if the table has large amounts of data in it this could make a huge performance impact on the server and create long wait times for the user.

            return db.ExecuteSqlCommand("TRUNCATE TABLE Picturerating");

            // in order to avoid all this hassle i used a SQL query in order to truncate the table. truncating a table means telling the target table to reset it's data to day 1.
            // not only does it remove all the records by talking on Table level in the database instead of each row which first has to come trough the application, it also resets all the
            // auto-incremented values back to their default starting value. this avoids large ID values when testing, keeping ID-related bugfixing easy.

        }


        #endregion

    }
}