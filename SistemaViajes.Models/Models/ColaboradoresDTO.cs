using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class ColaboradoresDTO
    {
        public int Colb_Id { get; set; }
        public string Colb_Codigo { get; set; }
        public string Colb_Identidad { get; set; }
        public string Colb_NombreCompleto { get; set; }
        public string Colb_Telefono { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime? Colb_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Colb_FechaModificacion { get; set; }
        public string Colb_Sexo { get; set; }
        public double Cosu_DistanciaKm { get; set; }

    }

    public class ColaboradorSucursalDTO
    {
        public int Sucu_Id { get; set; }
        public decimal CoSu_DistanciaKm { get; set; }
    }

    public class ColaboradoresInsertarDTO
    {
        public int Colb_Id { get; set; }
        public string Colb_Codigo { get; set; }
        public string Colb_Identidad { get; set; }
        public string Colb_NombreCompleto { get; set; }
        public string Colb_Telefono { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime? Colb_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Colb_FechaModificacion { get; set; }
        public string Colb_Sexo { get; set; }

        // ✨ Nueva propiedad para las sucursales asignadas
        public List<ColaboradorSucursalDTO> Sucursales { get; set; } = new List<ColaboradorSucursalDTO>();
    }
}
