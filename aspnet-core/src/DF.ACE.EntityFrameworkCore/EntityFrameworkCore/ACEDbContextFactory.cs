using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DF.ACE.Configuration;
using DF.ACE.Web;

namespace DF.ACE.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ACEDbContextFactory : IDesignTimeDbContextFactory<ACEDbContext>
    {
        public ACEDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ACEDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ACEDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ACEConsts.ConnectionStringName));

            return new ACEDbContext(builder.Options);
        }
    }
}
