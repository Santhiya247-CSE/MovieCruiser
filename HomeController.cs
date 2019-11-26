using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCruiser.Controllers
{
    public class HomeController : Controller
    {
        private MovieEntity Cruobj = new MovieEntity();
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form, Customer c)
        {
            var usrname = form["uname"];
            var passwd = form["pwd"];
            if (usrname == "San" && passwd == "san247")
            {
                return RedirectToAction("MovieAdmin");
            }
            else if (usrname == "Customer" && passwd == "cust123")
            {
                return RedirectToAction("MovieCustomer");
            }
            else
            {
                ViewBag.Message = "Login Invalid";
            }
            return View();


        }
        public ActionResult NewMovie(Movie mv)
        {
            try
            {
                Cruobj.movie.Add(mv);
                Cruobj.SaveChanges();
            }
            catch { }
        
            return View();
        }
        public ActionResult MovieAdmin()
        {
            var mvadm = Cruobj.movie.ToList();
            return View(mvadm);
           
        }
        public ActionResult MovieCustomer()
        {
            var mvcust = Cruobj.movie.ToList();
            return View(mvcust);
        }
        public ActionResult Edit()
        {
          

            return View();
        }

    }
}