using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BellaGalleria.Model.Models;
using BellaGalleria.Service;

namespace BellaGalleria.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artist;
        public ArtistController(IArtistService artist)
        {
            _artist = artist;
        }
        //
        // GET: /Artist/
        public ActionResult Index()
        {
            IEnumerable<Artist> Artists = _artist.GetArtists();
            return View(Artists);
        }

        //
        // GET: /Artist/Details/5
        public ActionResult Details(int id)
        {
            var artist = _artist.GetArtist(id);
            return View(artist);
        }

        //
        // GET: /Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _artist.CreateArtist(artist);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Please Enter Valid credentials");
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Artist/Edit/5
        public ActionResult Edit(int id)
        {
            var artist = _artist.GetArtist(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artist artist)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _artist.EditArtist(artist);
                    return RedirectToAction("Index");
                }
                return View(artist);
            }
            catch
            {
                return View(artist);
            }
        }

        //
        // GET: /Artist/Delete/5
        public ActionResult Delete(int id)
        {
            var artist = _artist.GetArtist(id);
            return View(artist);
        }

        //
        // POST: /Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Artist artist)
        {
            try
            {
                // TODO: Add delete logic here
                _artist.DeleteArtist(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(artist);
            }
        }
    }
}
