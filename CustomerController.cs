using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VR.Controllers;
using VR.Models;

namespace VR.Controllers
{
    public class CustomerController : Controller
    {
        public DbCustomers db = new DbCustomers();
        public DbMovie dm = new DbMovie();
        public DbRental rental= new DbRental();
        // GET: Customer
        [Authorize]
        public ActionResult Index()
        {
            return View(db.GetCustomers());
        }

        public ActionResult Detail(int customerId)
        {

            var rows = db.GetCustomers().Find(model => model.Cid == customerId);
            return View(rows);
        }

        [Authorize]
        public ActionResult Movie()
        {
            return View(dm.GetMovies());
        }

        public ActionResult MovieDetails(int movieid)
        {

            var rows = dm.GetMovies().Find(model => model.Mid == movieid);

            return View(rows);
        }

        [Authorize]
        public ActionResult AddC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddC(Customer c)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            db.AddCustomer(c);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var rows = db.GetCustomers().Find(m => m.Cid == id);
            return View(rows);
        }
        [HttpPost]
        public ActionResult Edit(Customer cc)
        {
            db.UpdateCustomer(cc);
            return View();
        }

        [Authorize]
        public ActionResult AddM()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddM(Movie m)
        {
            dm.AddM(m);
            return RedirectToAction("Movie");
        }

        public ActionResult Delete(int id)
        {
            db.DeleteC(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Delete(int id, Customer cc)
        //{
        //    int i = db.DeleteC(id);
        //    if (i > 0)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Delete");
        //    }

        //}

        public ActionResult DeleteM(int id)
        {
            var rows = dm.GetMovies().Find(m => m.Mid == id);
            return View(rows);
        }

        [HttpPost]
        public ActionResult DeleteM(int id, Movie m)
        {
            int i = dm.Delete(id);
            if (i > 0)
            {
                return RedirectToAction("Movie");
            }
            return View();
        }

        public ActionResult UpdateM(int id)
        {
            var rows=dm.GetMovies().Find(model=>model.Mid== id);
            return View(rows);
        }

        [HttpPost]
        public ActionResult UpdateM(Movie m)
        {
            int i=dm.UpdateM(m);
            if (i > 0)
            {
                return RedirectToAction("Movie");
            }
            return View();
            
        }

        [Authorize]
        public ActionResult Rental(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.movie=dm.GetMovies();
            mymodel.id=id;
            return View(mymodel);
        }
        [HttpPost]
        public ActionResult Rental(Rental re)
        {
            var rows=dm.GetMovies().Find(model=>model.Mid==re.Mid);
            if(rows.instock==0)
            {
                ViewBag.FirstNameError = "Movie Is out of stock";
                return Content("Movie Is out of stock");
            }
            else
            {
                rental.AddRental(re);

                return Content("success");
            }
           
           
        }

        public ActionResult rentallist(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.RendedDate = rental.RentalList().FindAll(model=>model.Cid==id);
            mymodel.MovieName = rental.RendedMovie(id);
            return View(mymodel);
        }

        public ActionResult MovieRentals(int id) 
        {
            var rows=rental.RentalNames(id);
            //ViewBag.Mrentals= rows.ToArray();
            return View(rows);

           
        }

        public ActionResult page(int no)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.all = db.GetCustomers();
            mymodel.page=db.paging(no);
            return View(mymodel);
        }

        public ActionResult row(int no) {
            dynamic mymodel = new ExpandoObject();
            mymodel.all = db.GetCustomers();
            mymodel.page = db.pagingRow(no);
            return View(mymodel);
        }
    }
}