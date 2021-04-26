using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CEntidad;

namespace CDatos
{
    public class ClaseDatos
    {
        SqlConnection conec = new SqlConnection
            (ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        SqlCommand cmd;

        public DataTable Log(ClaseEntidad dat)
        {
            cmd = new SqlCommand("logear", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@user", dat.user);
            cmd.Parameters.AddWithValue("@passw", dat.pass);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            conec.Close();

            return dt;

        }
        public DataTable Leer()
        {
            conec.Open();
            cmd = new SqlCommand("Cargar", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            conec.Close();
            return dt;
        }
        public void agregar(EntidadSocio socio)
        {

            cmd = new SqlCommand("insertarS", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@idsocio", socio.IDsocio);
            cmd.Parameters.AddWithValue("@tiposocio", socio.Tiposocio);
            cmd.Parameters.AddWithValue("@nombre", socio.Nombre);
            cmd.Parameters.AddWithValue("@apellido", socio.Apellido);
            cmd.Parameters.AddWithValue("@FullName", socio.NombreCompleto);
            cmd.Parameters.AddWithValue("@sexo", socio.Sexo);
            cmd.Parameters.AddWithValue("@cedula", socio.Cedula);
            cmd.Parameters.AddWithValue("@Fechaing", socio.FechaIngreso);
            cmd.Parameters.AddWithValue("@fechanac", socio.FechaNac);
            cmd.Parameters.AddWithValue("@direccion", socio.Direccion);
            cmd.Parameters.AddWithValue("@telefono", socio.Telefono);
            cmd.Parameters.AddWithValue("@Celular", socio.Celular);
            cmd.Parameters.AddWithValue("@email", socio.Email);
            cmd.Parameters.AddWithValue("@estatus", socio.Estatus);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conec.Close();
        }
        public void editar(EntidadSocio socio)
        {
            cmd = new SqlCommand("ActualizarS", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@idsocio", socio.IDsocio);
            cmd.Parameters.AddWithValue("@tiposocio", socio.Tiposocio);
            cmd.Parameters.AddWithValue("@nombre", socio.Nombre);
            cmd.Parameters.AddWithValue("@apellido", socio.Apellido);
            cmd.Parameters.AddWithValue("@FullName", socio.NombreCompleto);
            cmd.Parameters.AddWithValue("@sexo", socio.Sexo);
            cmd.Parameters.AddWithValue("@cedula", socio.Cedula);
            cmd.Parameters.AddWithValue("@Fechaing", socio.FechaIngreso);
            cmd.Parameters.AddWithValue("@fechanac", socio.FechaNac);
            cmd.Parameters.AddWithValue("@direccion", socio.Direccion);
            cmd.Parameters.AddWithValue("@telefono", socio.Telefono);
            cmd.Parameters.AddWithValue("@Celular", socio.Celular);
            cmd.Parameters.AddWithValue("@email", socio.Email);
            cmd.Parameters.AddWithValue("@estatus", socio.Estatus);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conec.Close();
        }
        public void borrar(string va)
        {
            cmd = new SqlCommand("BorrarS", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@cedula",va);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conec.Close();

            //cmd = new SqlCommand("delete from socios where Cedula='{socio.Cedula}'", conec);
            //cmd.ExecuteNonQuery();
            //conec.Close();
        }

        public DataTable busqueda(string val)
        {
            conec.Open();
            cmd = new SqlCommand("buscars", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busque", val);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            conec.Close();
            return dt;
        }

        public DataTable Mostrar()
        {
            conec.Open();
            cmd = new SqlCommand("select * from tiposocio", conec);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();

            adp.Fill(tb);
            conec.Close();

            return tb;
        }
        public void agregarTs (EntidadTipoSocio Tsocio)
        {

            cmd = new SqlCommand("insertarTS", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@tiposocio", Tsocio.Descripcion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conec.Close();
        }
        public void actualizarTS(EntidadTipoSocio Tsocio)
        {

            cmd = new SqlCommand("ActualizarTS", conec);
            cmd.CommandType = CommandType.StoredProcedure;
            conec.Open();
            cmd.Parameters.AddWithValue("@tiposocio", Tsocio.Descripcion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conec.Close();
        }
    }

}
