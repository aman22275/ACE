using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DF.ACE.Authorization.Roles;
using DF.ACE.Authorization.Users;
using DF.ACE.MultiTenancy;
using DF.ACE.Navigation;
using DF.ACE.Common.Attachment;

namespace DF.ACE.EntityFrameworkCore
{
    public class ACEDbContext : AbpZeroDbContext<Tenant, Role, User, ACEDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Demo> Demos { get; set; }
        public DbSet<ProfileAttachment> ProfileAttachments { get; set; }
        public DbSet<NavigationMenuItem> NavigationMenuItems { get; set; }
        public ACEDbContext(DbContextOptions<ACEDbContext> options)
            : base(options)
        {
        }
    }
}
