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




    public class ViajeListDTO
    {
        public int Viaj_Id { get; set; }
        public DateTime Viaj_Fecha { get; set; }

        // Sucursal
        public int Sucu_Id { get; set; }
        public string Sucu_Nombre { get; set; }
        public string Sucu_Direccion { get; set; }

        // Transportista
        public int Tran_Id { get; set; }
        public string Transportista { get; set; }
        public string TransportistaTelefono { get; set; }
        public decimal TarifaTransportista { get; set; }

        // Auditoría
        public int? Usua_Creacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? Viaj_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? Viaj_FechaModificacion { get; set; }

        // Totales calculados
        public decimal TotalKm { get; set; }
        public decimal TotalPagar { get; set; }
        public int CantidadColaboradores { get; set; }

        // Lista de colaboradores (se poblará después)
        public List<ColaboradorViajeDetalleDTO> Colaboradores { get; set; } = new List<ColaboradorViajeDetalleDTO>();
    }

    // ============================================
    // DTOs para el segundo result set (Colaboradores por Viaje)
    // ============================================
    public class ColaboradorViajeDetalleDTO
    {
        public int Viaj_Id { get; set; }
        public int Colb_Id { get; set; }
        public string Colb_Codigo { get; set; }
        public string Colb_Identidad { get; set; }
        public string Colb_NombreCompleto { get; set; }
        public string Colb_Telefono { get; set; }
        public string Colb_Sexo { get; set; }

        // Datos de viaje
        public decimal ClVj_DistanciaKm { get; set; }
        public decimal ClVj_TarifaPorKm { get; set; }
        public decimal PagoIndividual { get; set; }

        // Auditoría
        public int? Usua_Creacion { get; set; }
        public DateTime? ClVj_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? ClVj_FechaModificacion { get; set; }
    }
}
