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
            Session["Id"] = form["uname"].ToString();
            var usrname = int.Parse(Session["Id"].ToString());
            var passwd = form["pwd"];
            if (int.Parse(Session["Id"].ToString()) == 765025 && passwd == "san247")
            {
                return RedirectToAction("MovieAdmin");
            }
            var name = Cruobj.customer.Where(x => x.Customerid == usrname).FirstOrDefault();
            var pass = Cruobj.customer.Where(x => x.Password == passwd).FirstOrDefault(); 
            if(name!=null && pass != null)
            {
                return RedirectToAction("MovieCustomer", new { usrname = int.Parse(Session["Id"].ToString()) });
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
                ViewBag.Message = "New Movie Added Successfully!!";
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
        public ActionResult Edit(int id)
        {
           
            return View(Cruobj.movie.Where(x => x.M_Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                Cruobj.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                Cruobj.SaveChanges();
            }
            catch { }
            return RedirectToAction("EditMovieStatus");
            }
            public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Customer custlist)
        {
            try
            {
                Cruobj.customer.Add(custlist);
                Cruobj.SaveChanges();
                ViewBag.Message = "New User Account Created!!";
            }
            catch { };
            return View();
        }
        public ActionResult CustomerFavList()
        {

            var id = int.Parse(Session["Id"].ToString());
            var  fav = Cruobj.favorite.Where(x => x.Custid == id).ToList();
                int i = Cruobj.favorite.Where(x => x.Custid == id).Count();

            if (i == 0)
            {
                return RedirectToAction("FavListEmpty");
            }
            else
            {
                ViewBag.Message = i;
            }
            return View(fav);
            
            
        }
        public ActionResult FavListEmpty()
        {
            return View();
        }
        public ActionResult EditMovieStatus()
        {
            return View();
        }
        public ActionResult FavListSuccess(int id,Favorite flist)
        {
            try
            {
                var ml = Cruobj.movie.Where(x => x.M_Id == id).FirstOrDefault();
                var fav = new Favorite
                {
                    F_id=ml.M_Id,
                    M_Id = ml.M_Id,
                    M_Title = ml.M_Title,
                    M_Boxoffice = ml.M_BoxOffice,
                    Genre = ml.Genre,
                    Custid= int.Parse(Session["Id"].ToString())

            };
                Cruobj.favorite.Add(fav);
                Cruobj.SaveChanges();
            }
            catch { }
            return RedirectToAction("MovieCustomerNotification");
        }
        public  ActionResult MovieCustomerNotification()
        {
            var mvcs = Cruobj.movie.ToList();
            ViewBag.Message = "Movie Added to Favorites Successfully!!";
            return View(mvcs);
        }
        public ActionResult DeleteFavMovie(int id)
        {
            
                var cust = Cruobj.favorite.Where(f => f.M_Id == id).FirstOrDefault();
                Cruobj.favorite.Remove(cust);
                Cruobj.SaveChanges();
            
            return RedirectToAction("FavNotification");
        }
        public ActionResult FavNotification()
        {
            var id = int.Parse(Session["Id"].ToString());
            var favlist = Cruobj.favorite.Where(x=>x.Custid==id).ToList();
            int cnt = Cruobj.favorite.Where(x=>x.Custid==id).Count();
            if(cnt==0)
            {
                return RedirectToAction("FavListEmpty");
            }
            else
            {
                ViewBag.Message = cnt;
            }
            ViewBag.Message = "Movie Removed from Favorites:(";
            return View(favlist);
        }
        public ActionResult Logout()
        {
          
            return View();
        }
    }
}