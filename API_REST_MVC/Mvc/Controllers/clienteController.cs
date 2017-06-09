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
            lista = lc.listarcliente().Where(c => c.estado.Equals("1")).OrderByDescending(c => c.id_cliente).ToList();
            int tamaño = lista.Count;
            ViewBag.tamaño = tamaño;
            
            return View(lista);
        }

        public ActionResult GetProvincia(int id)
        {

            List<SelectListItem> Lisitem = new List<SelectListItem>();
            ladoCliente lc = new ladoCliente();
            List<provincia> pro = new List<provincia>();
            pro = lc.listarprovincia().Where(c=>c.id_departamento==id).ToList();
            foreach (var i in pro)
            {
                provincia prov = new provincia();
                prov.id_provincia = i.id_provincia;
                prov.descripcion = i.descripcion;
                SelectListItem item = new SelectListItem() { Value = prov.id_provincia.ToString(), Text=prov.descripcion};
                Lisitem.Add(item);
            }
            return new JsonResult { Data = Lisitem, JsonRequestBehavior= JsonRequestBehavior.AllowGet };
         }

        public ActionResult GetDistrito(int id)
        {
            List<SelectListItem> lisItem = new List<SelectListItem>();
            ladoCliente lc = new ladoCliente();
            List <distrito> dist = new List<distrito>();
            dist = lc.listardistrito().Where(c=>c.id_provincia==id).ToList();

            foreach (var d in dist) {
                distrito i = new distrito();
                i.id_distrito = d.id_distrito;
                i.descripcion = d.descripcion;
                SelectListItem item = new SelectListItem() { Value=i.id_distrito.ToString(), Text=i.descripcion};
                lisItem.Add(item);
            }
            return new JsonResult {Data=lisItem, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }


    // GET: cliente/Create
    public ActionResult Create()
        {
           
            ladoCliente lc = new ladoCliente();
            List<SelectListItem> dep_listitem = new List<SelectListItem>();
            List<departamento> dep = new List<departamento>();
            dep = lc.listardepartamento();

            foreach (var de in dep)
            {
                departamento iDep = new departamento();
                iDep.id_departamento = de.id_departamento;
                iDep.descripcion = de.descripcion;
                SelectListItem item = new SelectListItem() { Value = iDep.id_departamento.ToString(), Text = iDep.descripcion };
                dep_listitem.Add(item);
            }
            ViewBag.listarDepartamento = new SelectList(dep_listitem, "Value", "Text");

            List<SelectListItem> listitemPro = new List<SelectListItem>();
            ViewBag.listarProvincia = new SelectList(listitemPro,"Value","Text");

            List<SelectListItem> listitemDis = new List<SelectListItem>();
            ViewBag.listarDistrito = new SelectList(listitemDis, "Value", "Text");

            return View("Create");
        }

        // POST: cliente/Create
        [HttpPost]
        public ActionResult Create(cliente cliente)
        {
            try
            {
                ladoCliente lc = new ladoCliente();
                
                string nombre = cliente.nombre.ToString();
                string direccion = cliente.direccion.ToString();
                int id_distrito = (int)cliente.id_distrito;
               
                string estado = "1";
                cliente cli = new cliente();
                cli.nombre = nombre;
                cli.direccion = direccion;
                cli.id_distrito = id_distrito;
                cli.estado = estado;
                lc.agregar(cli);

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

            ///////////
            List<SelectListItem> dep_listitem = new List<SelectListItem>();
            List<departamento> dep = new List<departamento>();
            dep = lc.listardepartamento();

            foreach (var de in dep)
            {
                departamento iDep = new departamento();
                iDep.id_departamento = de.id_departamento;
                iDep.descripcion = de.descripcion;
                SelectListItem item = new SelectListItem() { Value = iDep.id_departamento.ToString(), Text = iDep.descripcion };
                dep_listitem.Add(item);
            }
            ViewBag.listarDepartamento = new SelectList(dep_listitem, "Value", "Text");

            /////////
            List<SelectListItem> pro_ListItem = new List<SelectListItem>();
            int id_departamento = (int)cli.distrito.provincia.departamento.id_departamento;
            List<provincia> lista_pro = new List<provincia>();
            lista_pro= lc.listarprovincia().Where(c => c.id_departamento == id_departamento).ToList();

            foreach (var var_pro in lista_pro)
            {
                provincia iPro = new provincia();
                iPro.id_provincia = var_pro.id_provincia;
                iPro.descripcion = var_pro.descripcion;
                SelectListItem item = new SelectListItem() { Value = iPro.id_provincia.ToString(), Text = iPro.descripcion };
                pro_ListItem.Add(item);
            }

            ViewBag.listarProvincia = new SelectList(pro_ListItem, "Value", "Text");

            /////////
            List<SelectListItem> ListItemDis = new List<SelectListItem>();
            int id_provincia = (int)cli.distrito.provincia.id_provincia;
            List<distrito> dis = new List<distrito>();
            dis= lc.listardistrito().Where(c => c.id_provincia == id_provincia).ToList();

            foreach (var di in dis)
            {
                distrito iDis = new distrito();
                iDis.id_distrito = di.id_distrito;
                iDis.descripcion = di.descripcion;
                SelectListItem item = new SelectListItem() { Value = iDis.id_distrito.ToString(), Text = iDis.descripcion };
                ListItemDis.Add(item);
            }
            ViewBag.listarDistrito = new SelectList(ListItemDis, "Value", "Text");

            return View(cli);
        }

        // POST: cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(cliente cliente)
        {
            try
            {
                // TODO: Add update logic here
              
                int id = (int)cliente.id_cliente;
                string nombre = cliente.nombre.ToString();
                string direccion = cliente.direccion.ToString();
                int id_distrito = (int)cliente.id_distrito;
               
                string estado = "1";

                cliente cli = new cliente();
                cli.id_cliente = id;
                cli.nombre = nombre;
                cli.direccion = direccion;
                cli.id_distrito = id_distrito;
                cli.estado = estado;
                ladoCliente lc = new ladoCliente();
                lc.modificar(cli);
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

                cliente cliente = new cliente();
                ladoCliente lc = new ladoCliente();
                cliente = lc.listarclientexuno(id);

               
                int id2 = (int)cliente.id_cliente;
                string nombre = cliente.nombre.ToString();
                string direccion = cliente.direccion.ToString();
                int id_distrito = (int)cliente.id_distrito;
                string estado = cliente.estado.ToString();
                estado="0";
                cliente cli = new cliente();
                cli.id_cliente = id2;
                cli.nombre = nombre;
                cli.direccion = direccion;
                cli.id_distrito = id_distrito;
                cli.estado = estado;
                
                lc.modificar(cli);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
