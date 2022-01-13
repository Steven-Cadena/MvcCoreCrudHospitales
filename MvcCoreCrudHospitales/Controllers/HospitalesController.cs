using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudHospitales.Models;
using MvcCoreCrudHospitales.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudHospitales.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospitales repo;
        public HospitalesController(RepositoryHospitales repo) 
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hospital hospital) 
        {
            this.repo.InsertarHospital(hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Cama);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id) 
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteHospital(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital
                ,hospital.Nombre,hospital.Direccion,hospital.Telefono,hospital.Cama);
            return RedirectToAction("Index");
        }


    }
}
