using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BellaGalleria.Core.Extensions;
using BellaGalleria.Model.Models;
using BellaGalleria.Data;
using BellaGalleria.Service;
using BellaGalleria.ViewModels;

namespace BellaGalleria.Controllers
{
    [Authorize]
    public class ArtworkController : Controller
    {
       // private BellaGalleriaEntities db = new BellaGalleriaEntities();
        private readonly IArtworkService _artworkService;
        private readonly ICategoryService _categoryService;

        public ArtworkController(IArtworkService artwork, ICategoryService categoryService)
        {
            _artworkService = artwork;
            _categoryService = categoryService;
        }

        // GET: /Artwork/
        public ActionResult Index()
        {
            var artworks =  _artworkService.GetArtworks();
            return View(artworks);
        }

        // GET: /Artwork/Details/5
        public ActionResult Details(int id)
        {
            Artwork artwork = _artworkService.GetArtwork(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // GET: /Artwork/Create
        public ActionResult Create()
        {
            var artwork = new ArtworkFormViewModel();
            IEnumerable<Category> categories =_categoryService.GetCategories();
            artwork.Categories = categories.ToSelectListItems(-1);
            return View(artwork);
        }

        // POST: /Artwork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtworkFormViewModel artworkForm)
        {
            //[Bind(Include="Id,Title,Description,Price,Created,ImageUrl")] 
            Artwork artwork = Mapper.Map<ArtworkFormViewModel, Artwork>(artworkForm);
            if (ModelState.IsValid)
            {
                _artworkService.CreateArtwork(artwork);
                _artworkService.SaveArtwork();
                return RedirectToAction("Index");
            }

            return View(artwork);
        }

        // GET: /Artwork/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = _artworkService.GetArtwork(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: /Artwork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Description,Price,Created,ImageUrl")] Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                _artworkService.EditArtwork(artwork);
                _artworkService.SaveArtwork();
                return RedirectToAction("Index");
            }
            return View(artwork);
        }

        // GET: /Artwork/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = _artworkService.GetArtwork(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: /Artwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artwork artwork = _artworkService.GetArtwork(id);
            _artworkService.DeleteArtwork(artwork);
            _artworkService.SaveArtwork();
            return RedirectToAction("Index");
        }
        
    }
}
