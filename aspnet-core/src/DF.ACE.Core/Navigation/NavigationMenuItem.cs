using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace DF.ACE.Navigation
{
	[Table("ACE_NavigationMenuItems")]
	public class NavigationMenuItem : FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string DisplayName { get; set; }
		[CanBeNull] public string Icon { get; set; }
		[CanBeNull] public string Url { get; set; }
		public bool RequiresAuthentication { get; set; }
		public string RequiredPermissionName { get; set; }
		public int DisplayOrder { get; set; }
		[CanBeNull] public string CustomData { get; set; }
		[CanBeNull] public string Target { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsVisible { get; set; }
		[CanBeNull]
		[ForeignKey("ParentNavigationMenuItemId")]
		public NavigationMenuItem Parent { get; set; }
		[ForeignKey("ParentNavigationMenuItemId")]
		public virtual ICollection<NavigationMenuItem> Children { get; set; }
	}
}
