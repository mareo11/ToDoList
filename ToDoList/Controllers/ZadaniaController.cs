using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    public class ZadaniaController : Controller
    {
        private readonly IZadaniaRepsitory zadaniaRepository;

        public ZadaniaController(IZadaniaRepsitory zadaniaRepository)
        {
            this.zadaniaRepository = zadaniaRepository;
        }



        // GET: ZadaniaController
        public ActionResult Index()
        {
            return View(zadaniaRepository.GetAllActive());
        }

        public ActionResult TasksPerformed()
        {
            return View(zadaniaRepository.GetZadaniaWykonane());
        }

        public ActionResult TimedTasks()
        {
            return View(zadaniaRepository.GetZadaniaPoCzasie());
        }

        // GET: ZadaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View(zadaniaRepository.Get(id));
        }

        // GET: ZadaniaController/Create
        public ActionResult Create()
        {
            return View(new ZadaniaModelcs());
        }

        // POST: ZadaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZadaniaModelcs zadaniaModel)
        {

            if (zadaniaModel.Data >= DateTime.Now)
            {
                zadaniaRepository.Add(zadaniaModel);
                return RedirectToAction(nameof(Index));
                
            }
            else
            {
                ModelState.AddModelError("Data", "Zmień Datę. Nie można skończyć zadania w przeszłości!!");
                return View(zadaniaModel);
            }

        }

        // GET: ZadaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(zadaniaRepository.Get(id));
        }

        // POST: ZadaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ZadaniaModelcs zadaniaModel)
        {
            zadaniaRepository.Update(id, zadaniaModel);
            
            return RedirectToAction(nameof(Index));
            
            
        }

        // GET: ZadaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(zadaniaRepository.Get(id));
        }

        // POST: ZadaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ZadaniaModelcs zadaniaModels)
        {
            zadaniaRepository.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
      

        public ActionResult Done(int id, ZadaniaModelcs zadaniaModels)
        {
            zadaniaRepository.Wykonane(id, zadaniaModels);
            return RedirectToAction(nameof(Index));

        }
    }
}
