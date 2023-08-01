using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WebAPIBoilerPlate.EntityFrameworkCore
{
    public static class WebAPIBoilerPlateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebAPIBoilerPlateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WebAPIBoilerPlateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
