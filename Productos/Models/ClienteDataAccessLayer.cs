using Productos.Data;
using System.Data.SqlClient;

namespace Productos.Models
{
    public class ClienteDataAccessLayer
    {
        string connectionString = "Server=localhost;Database=Productos;User ID=sa;Password=@Dante12Al2004;TrustServerCertificate=True;MultipleActiveResultSets=true";

        public List<Cliente> getAllClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Close();
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(rdr["Codigo"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Apellidos = rdr["Apellidos"].ToString();
                    cliente.Nombres = rdr["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["Mail"].ToString();
                    cliente.Telefono = rdr["Telefono"].ToString();
                    cliente.Direccion = rdr["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(rdr["Estado"]);
                    lstCliente.Add(cliente);
                }
                con.Close();
            }
            return lstCliente;
        }

        public void addCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Cliente_Insert", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                        cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                        // Abrir conexión
                        con.Open();

                        // Ejecutar el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al agregar el cliente: " + ex.Message);
            }
        }

        public void updateCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Cliente_Update", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                        cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                        cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                        // Abrir conexión
                        con.Open();
                        // Ejecutar el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al actualizar el cliente: " + ex.Message);
            }
        }

        public void deleteCliente(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Cliente_Delete", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.AddWithValue("@Codigo", id);
                        // Abrir conexión
                        con.Open();
                        // Ejecutar el procedimiento almacenado
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al eliminar el cliente: " + ex.Message);
            }
        }
    }
}
