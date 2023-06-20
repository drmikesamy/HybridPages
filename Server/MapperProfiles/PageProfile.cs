using AutoMapper;
using HybridPages.Shared.Models;

namespace HybridPages.Server.MapperProfiles
{
	public class PageProfile : Profile
	{
		public PageProfile() {
			CreateMap<Page, Page>();
		}
	}
}
