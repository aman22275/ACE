using System.Linq;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DF.ACE.Navigation.Dto;
using Microsoft.EntityFrameworkCore;

namespace DF.ACE.Navigation
{
	public class NavigationMenuItemAppService :
		AsyncCrudAppService<NavigationMenuItem, NavigationMenuItemDto, long, PagedAndSortedResultRequestDto,
			NavigationMenuItemDto, NavigationMenuItemDto>, INavigationMenuItemAppService
	{
		public NavigationMenuItemAppService(IRepository<NavigationMenuItem, long> repository) : base(repository)
		{
		}

		protected override IQueryable<NavigationMenuItem> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
		{
			return base.CreateFilteredQuery(input).Include(n => n.Parent).Include(n => n.Children);
		}
	}
}