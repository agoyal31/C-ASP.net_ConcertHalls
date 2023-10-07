using AG2237A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG2237A1.Controllers
{
    public class VenuesController : Controller
    {
        private Manager manager = new Manager();

        // GET: Venue
        public ActionResult Index()
        {
            var venues = manager.VenueGetAll();
            return View(venues);
        }

        // GET: Venue/Details/5
        public ActionResult Details(int ? id)
        {// attempt to get the matching object
            var venue = manager.VenueGetById(id.GetValueOrDefault());

            if(venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venue);

            }
        }

        // GET: Venue/Create
        public ActionResult Create()
        {
            var emptyObj = new VenueBaseViewModel();
            return View(emptyObj);
        }

        // POST: Venue/Create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel newVenue)
        {
            if (!ModelState.IsValid)
            {
                return View(newVenue);
            }
            try
            {
                // TODO: Add insert logic here
                var addedVenue = manager.VenueAdd(newVenue);
                if (addedVenue == null)
                {
                    return View(newVenue);
                }
                else
                {
                    return RedirectToAction("Details", new { id = addedVenue.VenueId});
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Venue/Edit/5
        public ActionResult Edit(int ? id)
        {
            var venue = manager.EditVenueGetById(id.GetValueOrDefault());

            if (venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venue);

            }
        }

        // POST: Venue/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
