using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.DataAccess;
using SistemaViajes.DataAccess.Repositories.Gral;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            // Configura la cadena de conexión del context
            SistemaViajesContext.BuildConnectionString(connectionString);

            // Repositorios
            services.AddScoped<DepartamentosRepository>();
            services.AddScoped<MunicipiosRepository>();
            services.AddScoped<SucursalesRepository>();

            services.AddScoped<ColaboradoresRepository>();

        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GralServices>();
            services.AddScoped<RRHHServices>();
        }



    }
}
