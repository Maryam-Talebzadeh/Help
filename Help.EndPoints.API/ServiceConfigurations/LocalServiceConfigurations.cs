using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Help.EndPoints.API.ServiceConfigurations
{
    public class LocalServiceConfigurations
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region DBContext

            services.AddDbContext<HelpContext>(x => x.UseSqlServer(connectionString));

            #endregion
        }
    }
}
