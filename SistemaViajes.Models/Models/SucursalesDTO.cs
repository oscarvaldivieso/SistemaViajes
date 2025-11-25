using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class SucursalesDTO
    {
        public int Sucu_Id { get; set; }
        public string Sucu_Codigo { get; set; }
        public string Sucu_Nombre { get; set; }
        public string Sucu_Direccion { get; set; }
        public string Muni_Codigo { get; set; }
        public string Sucu_Imagen { get; set; }
        public int Usua_Creacion { get; set; }
        public int? Usua_Modificacion { get; set; }
    }
}
