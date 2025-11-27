using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SistemaViajes.Models.Models
{
    // DTO para el colaborador en el viaje
    public class ColaboradorViajeDTO
    {
        public int Colb_Id { get; set; }
        public decimal ClVj_DistanciaKm { get; set; }
    }

    // DTO principal para el viaje
    public class ViajesDTO
    {
        public int Viaj_Id { get; set; }
        public DateTime Viaj_Fecha { get; set; }
        public int Sucu_Id { get; set; }
        public int Tran_Id { get; set; }
        public int? Usua_Creacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Viaj_FechaCreacion { get; set; }

        // Lista de colaboradores para el viaje
        public List<ColaboradorViajeDTO> Colaboradores { get; set; } = new List<ColaboradorViajeDTO>();
    }
}
