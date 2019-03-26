﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskOdd.Models;
using PagedList;

namespace TaskOdd.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index(int? page, string searchString, string sortOrder)
        {
            var games = db.Games.Include(g => g.Genre).Include(g => g.Rating);

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.Name.Contains(searchString));
            }

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "genre_asc" ? "genre_desc" : "genre_asc";
            ViewBag.RatingSortParm = sortOrder == "rating_asc" ? "rating_desc" : "rating_asc";

            ViewBag.CurrentSortParm = sortOrder;
            ViewBag.NameSearch = searchString;

            switch (sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(x => x.Name);
                    break;
                case "genre_desc":
                    games = games.OrderByDescending(x => x.Genre.GenreName);
                    break;
                case "genre_asc":
                    games = games.OrderBy(x => x.Genre.GenreName);
                    break;
                case "rating_desc":
                    games = games.OrderByDescending(x => x.Rating.RatingValue);
                    break;
                case "rating_asc":
                    games = games.OrderBy(x => x.Rating.RatingValue);
                    break;
                default:
                    games = games.OrderBy(x => x.Name);
                    break;
            }


            return View(games.ToPagedList(page ?? 1, 5));
        }
        [Authorize] //[Authorize(Roles = "User")]
        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [Authorize(Roles ="Admin")]
        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingValue");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Name,DOB,GenreId,RatingId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", game.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingValue", game.RatingId);
            return View(game);
        }

        [Authorize(Roles = "Admin")]
        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", game.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingValue", game.RatingId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Name,DOB,GenreId,RatingId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", game.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "RatingValue", game.RatingId);
            return View(game);
        }

        [Authorize(Roles = "Admin")]
        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
