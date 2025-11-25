using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class DepartamentosDTO
    {
        public string Depa_Codigo { get; set; }
        public string Depa_Nombre { get; set; }
        public DateTime? Depa_FechaModificacion { get; set; }
        public DateTime? Depa_FechaCreacion { get; set; }
        public int Usua_Creacion { get; set; }
        public int Usua_Modificacion { get; set; }
    }
}
