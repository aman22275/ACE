using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DF.ACE.Navigation.Dto;

namespace DF.ACE.Navigation
{
	public interface INavigationMenuItemAppService : IAsyncCrudAppService<NavigationMenuItemDto, long,
		PagedAndSortedResultRequestDto, NavigationMenuItemDto, NavigationMenuItemDto>
	{
	}
}