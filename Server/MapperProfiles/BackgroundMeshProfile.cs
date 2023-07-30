using AutoMapper;
using HybridPages.Shared.Models;
using HybridPages.Shared.Models.Styling;

namespace HybridPages.Server.MapperProfiles
{
	public class BackgroundMeshProfile : Profile
	{
		public BackgroundMeshProfile()
		{
			CreateMap<BackgroundMesh, BackgroundMesh>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());
			CreateMap<ColourPoint, ColourPoint>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());
		}
	}
}
