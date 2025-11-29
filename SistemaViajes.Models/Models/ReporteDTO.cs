using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    // DTO para el request
    public class ViajesReporteRequestDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int? Tran_Id { get; set; }
    }

    public class ViajeDetalleReporteDTO
    {
        public int Viaj_Id { get; set; }
        public DateTime Viaj_Fecha { get; set; }

        // Transportista
        public int Tran_Id { get; set; }
        public string Tran_Identidad { get; set; }
        public string Tran_Nombre { get; set; }
        public string Tran_Telefono { get; set; }
        public decimal Tran_TarifaPorKm { get; set; }

        // Sucursal
        public int Sucu_Id { get; set; }
        public string Sucu_Nombre { get; set; }
        public string Sucu_Direccion { get; set; }

        // Colaborador
        public int Colb_Id { get; set; }
        public string Colb_Codigo { get; set; }
        public string Colb_DNI { get; set; }
        public string Colb_Nombre { get; set; }
        public string Colb_Telefono { get; set; }
        public string Colb_Sexo { get; set; }

        // Datos del viaje
        public decimal ClVj_TarifaPorKm { get; set; }
        public decimal ClVj_DistanciaKm { get; set; }
        public decimal MontoPorColaborador { get; set; }

        // Auditoría
        public int Usua_Creacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime Viaj_FechaCreacion { get; set; }
    }

    public class TransportistaResumenReporteDTO
    {
        public int Tran_Id { get; set; }
        public string Tran_Identidad { get; set; }
        public string Tran_Nombre { get; set; }
        public string Tran_Telefono { get; set; }
        public decimal Tran_TarifaPorKm { get; set; }
        public int TotalViajes { get; set; }
        public int TotalColaboradores { get; set; }
        public decimal TotalKilometros { get; set; }
        public decimal TotalAPagar { get; set; }
    }

    public class ViajesReporteResponseDTO
    {
        public List<ViajeDetalleReporteDTO> DetalleViajes { get; set; }
        public List<TransportistaResumenReporteDTO> ResumenTransportistas { get; set; }
    }
}
