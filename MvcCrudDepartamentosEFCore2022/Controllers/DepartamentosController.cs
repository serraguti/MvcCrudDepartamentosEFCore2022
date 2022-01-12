using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosEFCore2022.Models;
using MvcCrudDepartamentosEFCore2022.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudDepartamentosEFCore2022.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertarDepartamento
                (departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
