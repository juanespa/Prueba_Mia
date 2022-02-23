using Prueba_Mia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Mia.Controllers
{
    public class ClienteController : Controller
    {
        private Cliente cliente = new Cliente();
        private int algo;
        // GET: Cliente
        public ActionResult Index()
        {
            return View(cliente.listarClientes());
        }

        public  ActionResult Crear(Cliente clientee)
        {
            if (clientee.Nombre == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                cliente.CrearCliente(clientee);
            }
            TempData["SuccessMessage"] = "Usuario Creado Correctamente ";
            return RedirectToAction("Index");


        }


        public ActionResult Ver(int id)
        {
            return View( cliente.VerCliente(id));
        }

        public ActionResult Eliminar(int id)
        {
            var a = cliente.Eliminar(id);
            TempData["SuccessMessage"] = $"Usuario con Id: {a.Cedula} y Nombre { a.Nombre}, Eliminado correctamente ";
            return RedirectToAction("Index");
        }

    }
}