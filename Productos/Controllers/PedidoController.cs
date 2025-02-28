using Microsoft.AspNetCore.Mvc;
using Productos.Data;
using Productos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Productos.Controllers
{
    public class PedidoController : Controller
    {
        PedidoDataAccessLayer objPedidoDAL = new PedidoDataAccessLayer();

        // Visualizar todos los pedidos
        public IActionResult Index()
        {
            List<Pedido> pedidos = objPedidoDAL.getAllPedidos().ToList();
            return View(pedidos);
        }

        // Crear un nuevo pedido
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Pedido objPedido)
        {
            if (ModelState.IsValid)
            {
                objPedidoDAL.addPedido(objPedido);
                return RedirectToAction("Index");
            }
            return View(objPedido);
        }

        // Editar un pedido
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Pedido> pedidos = objPedidoDAL.getAllPedidos();
            Pedido pedido = pedidos.FirstOrDefault(p => p.PedidoID == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Pedido objPedido)
        {
            if (id != objPedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                objPedidoDAL.updatePedido(objPedido);
                return RedirectToAction("Index");
            }

            return View(objPedido);
        }

        // Eliminar un pedido
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            List<Pedido> pedidos = objPedidoDAL.getAllPedidos();
            Pedido pedido = pedidos.FirstOrDefault(p => p.PedidoID == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // Procesar la eliminación de un pedido
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objPedidoDAL.deletePedido(id);
            return RedirectToAction("Index");
        }
    }
}
