using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DF.ACE.EntityFrameworkCore
{
    public static class ACEDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ACEDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ACEDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
