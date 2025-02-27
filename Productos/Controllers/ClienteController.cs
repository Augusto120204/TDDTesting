using Microsoft.AspNetCore.Mvc;
using Productos.Data;
using Productos.Models;

namespace Productos.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();

        // Visualizar todos los clientes
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.getAllClientes().ToList();
            return View(clientes);
        }

        // Crear un nuevo cliente
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                objClienteDAL.addCliente(objCliente);
                return RedirectToAction("Index");
            }
            return View(objCliente);
        }

        // Editar un cliente
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Cliente> clientes = objClienteDAL.getAllClientes();
            Cliente cliente = clientes.FirstOrDefault(c => c.Codigo == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente objCliente)
        {
            if (id != objCliente.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                objClienteDAL.updateCliente(objCliente);
                return RedirectToAction("Index");
            }

            return View(objCliente);
        }

        // Eliminar un cliente
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            List<Cliente> clientes = objClienteDAL.getAllClientes();
            Cliente cliente = clientes.FirstOrDefault(c => c.Codigo == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Procesar la eliminación de un cliente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objClienteDAL.deleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
