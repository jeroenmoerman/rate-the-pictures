using System.Linq;
using System.Web.Mvc;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    public class RatingresultController : Controller
    {

        #region Setup

        // JEMO : declare the database context so it can be used in this controller
        private TestProjectContext db = new TestProjectContext();


        #endregion



        #region Request Action methods


        // GET: Ratingresults
        public ActionResult Index()
        {
            RatingresultViewModel viewModel = CreateRatingresultViewModel();
            return View(viewModel.Pictureratings);
        }


        #endregion



        #region Handling methods


        private RatingresultViewModel CreateRatingresultViewModel()
        {
            return new RatingresultViewModel { Pictureratings = db.Pictureratings.ToList<Picturerating>() };
        }


        #endregion


    }
}