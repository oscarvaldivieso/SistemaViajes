using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.Models.Models
{
    public class LoginRequestDTO
    {
        public string Usua_Usuario { get; set; }
        public string Usua_Clave { get; set; }
    }


    public class LoginResponseDTO
    {
        public string Resultado { get; set; }
        public string Mensaje { get; set; }
        public int? Usua_Id { get; set; }
        public string Usua_Usuario { get; set; }
        public int? Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
    }


    public class JwtResponseDTO
    {
        public string token { get; set; }
        public int? Usua_Id { get; set; }
        public string Usua_Usuario { get; set; }
        public int? Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
        public DateTime expires_at { get; set; }
    }
}
