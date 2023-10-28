using api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace api.Data
{
    public class InventarioData
    {

        public static bool Registrar(Inventario oInventario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarInventario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oInventario.Nombre);
                cmd.Parameters.AddWithValue("@Precio", oInventario.Precio);
                cmd.Parameters.AddWithValue("@Stock", oInventario.Stock);
                cmd.Parameters.AddWithValue("@Proveedor", oInventario.Proveedor);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Inventario oInventario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificarInventario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInventario ", oInventario.IdInventario);
                cmd.Parameters.AddWithValue("@nombre", oInventario.Nombre);
                cmd.Parameters.AddWithValue("@Precio", oInventario.Precio);
                cmd.Parameters.AddWithValue("@Stock", oInventario.Stock);
                cmd.Parameters.AddWithValue("@Proveedor", oInventario.Proveedor);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }   
        }

        public static List<Inventario> Listar()
        {
            List<Inventario> oListaInventario = new List<Inventario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarInventario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaInventario.Add(new Inventario()
                            {
                                IdInventario = Convert.ToInt32(dr["IdInventario"]),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = dr["Precio"].ToString(),
                                Stock = dr["Stock"].ToString(),
                                Proveedor = dr["Proveedor"].ToString()
                            });
                        }

                    }



                    return oListaInventario;
                }
                catch (Exception ex)
                {
                    return oListaInventario;
                }
            }
        }

        public static Inventario Obtener(int IdInventario)
        {
            Inventario oInventario = new Inventario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand(" usp_obtenerInventario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdInventario", IdInventario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oInventario = new Inventario()
                            {
                                IdInventario = Convert.ToInt32(dr["IdInventario"]),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = dr["Precio"].ToString(),
                                Stock = dr["Stock"].ToString(),
                                Proveedor = dr["Proveedor"].ToString()
                            };
                        }

                    }
                    return oInventario;

                }

                catch (Exception ex)
                {
                    return oInventario;
                }
            }
        }



        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


    }
}