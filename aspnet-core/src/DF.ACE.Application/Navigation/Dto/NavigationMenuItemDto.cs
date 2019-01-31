using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JetBrains.Annotations;

namespace DF.ACE.Navigation.Dto
{
	[AutoMapTo(typeof(NavigationMenuItem))]
	public class NavigationMenuItemDto : EntityDto<long>
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
		[CanBeNull] public NavigationMenuItem Parent { get; set; }
		[NotMapped]
		public long? ParentNavigationMenuItemId { get; set; }
		public virtual ICollection<NavigationMenuItem> Children { get; set; }
	}
}
