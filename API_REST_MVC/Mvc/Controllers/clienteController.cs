using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class clienteController : Controller
    {
        
        // GET: cliente
        public ActionResult Index()
        {
            List<cliente> lista = new List<cliente>();
            ladoCliente lc = new ladoCliente();
            lista = lc.listarcliente();
            return View(lista);
        }

     
        // GET: cliente/Create
        public ActionResult Create()
        {
            List<SelectListItem> listitem = new List<SelectListItem>();
            List<departamento> dep = new List<departamento>();
            ladoCliente lc = new ladoCliente();
            dep = lc.listardepartamento();
            foreach (var i in dep) {
                SelectListItem item = new SelectListItem() {Value=i.id_departamento.ToString(),Text=i.descripcion };
                listitem.Add(item);
            }
            ViewBag.listarDepartamento = new SelectList(listitem, "Value", "Text");
            return View("Create");
        }

        // POST: cliente/Create
        [HttpPost]
        public ActionResult Create(cliente cliente)
        {
            try
            {
                ladoCliente lc = new ladoCliente();

                lc.agregar(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(int id)
        {
            ladoCliente lc = new ladoCliente();
            cliente cli = new cliente();
            cli = lc.listarclientexuno(id);

            List<SelectListItem> listitem = new List<SelectListItem>();
            List<departamento> dep = new List<departamento>();
            dep = lc.listardepartamento();
            foreach (var i in dep)
            {
                SelectListItem item = new SelectListItem() { Value = i.id_departamento.ToString(), Text = i.descripcion };
                listitem.Add(item);
            }
            ViewBag.listarDepartamento = new SelectList(listitem, "Value", "Text");

            return View(cli);
        }

        // POST: cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(cliente cliente)
        {
            try
            {
                // TODO: Add update logic here
                ladoCliente lc = new ladoCliente();
                lc.modificar(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: cliente/Delete/5
        [HttpGet]
        public ActionResult Delete(int id, cliente cli)
        {
            ladoCliente lc = new ladoCliente();
            cliente cliente = new cliente();
            cliente = lc.listarclientexuno(id);
            return View(cliente);
        }

        // POST: cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ladoCliente lc = new ladoCliente();
                lc.eliminar(id); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
