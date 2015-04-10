using System.Web.Mvc;
using BellaGalleria.Service;

namespace BellaGalleria.Controllers
{
    public class HomeController : Controller
    {
        private IArtistService _artist;
        public HomeController(IArtistService artist)
        {
            _artist = artist;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ViewResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
	}
}