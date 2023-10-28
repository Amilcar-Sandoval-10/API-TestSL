using api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace api.Data
{
    public class ProveedorData
    {



        public static bool Registrar(Proveedor oProveedor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", oProveedor.Cedula);
                cmd.Parameters.AddWithValue("@nombres", oProveedor.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oProveedor.Telefono);
                cmd.Parameters.AddWithValue("@correo", oProveedor.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oProveedor.Ciudad);

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

        public static bool Modificar(Proveedor oProveedor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificarProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", oProveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@Cedula", oProveedor.Cedula);
                cmd.Parameters.AddWithValue("@nombres", oProveedor.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oProveedor.Telefono);
                cmd.Parameters.AddWithValue("@correo", oProveedor.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oProveedor.Ciudad);

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

        public static List<Proveedor> Listar()
        {
            List<Proveedor> oListaProveedor = new List<Proveedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaProveedor.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString()
                            });
                        }

                    }



                    return oListaProveedor;
                }
                catch (Exception ex)
                {
                    return oListaProveedor;
                }
            }
        }

        public static Proveedor Obtener(int IdProveedor)
        {
            Proveedor oCliente = new Proveedor();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdProveedor", IdProveedor);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString()
                            };
                        }

                    }
                    return oCliente;

                }

                catch (Exception ex)
                {
                    return oCliente;
                }
            }
        }



        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarProveedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", id);

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