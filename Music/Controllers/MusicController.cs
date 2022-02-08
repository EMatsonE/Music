using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Music.Models;

namespace Music.Controllers
{
    public class MusicController : Controller
    {
        // GET: MusicController
        List<Data> _musicCollection;

        [HttpGet]
        public ActionResult Index()
        {
            string apiUri = "https://deezerdevs-deezer.p.rapidapi.com/search?q=rock";
            var apiTask = apiUri.WithHeaders(new
            {
                x_rapidapi_host = "deezerdevs-deezer.p.rapidapi.com",
                x_rapidapi_key = "a5b04e6222mshe0376e842564881p134a29jsnd3f1bd79e8cc"
            }).GetJsonAsync<MusicResults>();

            apiTask.Wait();

            _musicCollection = apiTask.Result.data;

            return View(_musicCollection);
        }

        [HttpPost]
        public ActionResult Index(string musicTitle = "rock")
        {
            string apiUri = $"https://deezerdevs-deezer.p.rapidapi.com/search?q={musicTitle}";
            var apiTask = apiUri.WithHeaders(new
            {
                x_rapidapi_host = "deezerdevs-deezer.p.rapidapi.com",
                x_rapidapi_key = "a5b04e6222mshe0376e842564881p134a29jsnd3f1bd79e8cc"
            }).GetJsonAsync<MusicResults>();

            apiTask.Wait();

            _musicCollection = apiTask.Result.data;

            return View(_musicCollection);
        }

        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
