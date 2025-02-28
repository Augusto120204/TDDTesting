using Productos.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Productos.Models
{
    public class PedidoDataAccessLayer
    {
        string connectionString = "Server=localhost;Database=Productos;User ID=sa;Password=@Dante12Al2004;TrustServerCertificate=True;MultipleActiveResultSets=true";

        public List<Pedido> getAllPedidos()
        {
            List<Pedido> lstPedido = new List<Pedido>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Pedido_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                    lstPedido.Add(pedido);
                }
                con.Close();
            }
            return lstPedido;
        }

        public void addPedido(Pedido pedido)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Pedido_Insert", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                        cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                        cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el pedido: " + ex.Message);
            }
        }

        public void updatePedido(Pedido pedido)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Pedido_Update", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PedidoID", pedido.PedidoID);
                        cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                        cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                        cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                        cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pedido: " + ex.Message);
            }
        }

        public void deletePedido(int pedidoID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Pedido_Delete", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PedidoID", pedidoID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pedido: " + ex.Message);
            }
        }
    }
}
