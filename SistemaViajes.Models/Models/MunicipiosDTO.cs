using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class MunicipiosDTO
    {
        public string Muni_Codigo { get; set; }

        public string Muni_Nombre { get; set; }

        public string Depa_Codigo { get; set; }

        [NotMapped]
        public string Depa_Nombre { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Munic_FechaCreacion { get; set; }

        public int Usua_Modificacion { get; set; }

        public DateTime Munic_FechaModificacion { get; set; }
    }
}
