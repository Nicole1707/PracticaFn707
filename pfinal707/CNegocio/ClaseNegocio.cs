using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CDatos;
using CEntidad;

namespace CNegocio
{
    public class ClaseNegocio
    {
        ClaseDatos ejc = new ClaseDatos();

        public DataTable logear(ClaseEntidad usua)
        {
            return ejc.Log(usua);
        }
        public void agregar(EntidadSocio Socio)
        {
            ejc.agregar(Socio);
        }
        public void editar(EntidadSocio Socio)
        {
            ejc.editar(Socio);
        }
        public DataTable Leer()
        {
            return ejc.Leer();
        }
        public void borrar(string val)
        {
            ejc.borrar(val);
        }
        public DataTable Busqueda(string val)
        {
            return ejc.busqueda(val);

        }
        public DataTable Mostrar()
        {
            return ejc.Mostrar();
        }
        public void agregarTs(EntidadTipoSocio Tsocio)
        {
            ejc.agregarTs(Tsocio);
        }
        public void actualizarTS(EntidadTipoSocio Tsocio)
        {
            ejc.actualizarTS(Tsocio);
        }
    }
}
