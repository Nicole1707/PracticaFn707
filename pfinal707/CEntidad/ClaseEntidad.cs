using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidad
{
    public class ClaseEntidad
    {
        
            public string user { get; set; }
            public string pass { get; set; }
    }
    public class EntidadSocio
    {
        public string IDsocio { get; set; }
        public int Tiposocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estatus { get; set; }
     
    }
    public class EntidadTipoSocio
    {
        public string Descripcion { get; set; }
    
    }
}
