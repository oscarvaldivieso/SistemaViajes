using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class TransportistasDTO
    {
        public int Tran_Id { get; set; }
        public string Tran_Identidad { get; set; }
        public string Tran_NombreCompleto { get; set; }
        public string Tran_Telefono { get; set; }
        public decimal Tran_TarifaPorKm { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime? Colb_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Colb_FechaModificacion { get; set; }
    }
}
