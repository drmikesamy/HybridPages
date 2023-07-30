using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HybridPages.Server.Data;
using HybridPages.Shared.Models;
using System.Security.Claims;
using AutoMapper;
using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.Styling;

namespace HybridPages.Server.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class PostController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private IMapper _mapper;
		public PostController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		[HttpGet("{uniqueName}")]
		public async Task<ActionResult<Page>> GetPage(string uniqueName)
		{
			var page = await _context.Pages
				.Include(m => m.PageMeta)
				.Include(m => m.Posts)
				.Include(m => m.Style.HeadingFontFace)
				.Include(m => m.Style.ParagraphFontFace)
				.Include(m => m.Style.BackgroundMesh.ColourPoints)
				.SingleOrDefaultAsync(m => m.UniqueName == uniqueName);
			if (page == null)
			{
				var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault();

				var defaultBackgroundMesh = await _context.BackgroundMeshes.Include(b => b.ColourPoints).FirstAsync();

				page = new Page
				{
					UniqueName = uniqueName,
					Title = uniqueName,
					FeaturedImageUrl = ""
				};
			}
			return Ok(page);
		}

		[HttpPost]
		public async Task<ActionResult<long>> Add(Tuple<Post, string> postWithUniqueName)
		{
			var post = postWithUniqueName.Item1;

			var page = await _context.Pages
				.Include(m => m.PageMeta)
				.Include(m => m.Posts)
				.Include(m => m.Style.HeadingFontFace)
				.Include(m => m.Style.ParagraphFontFace)
				.Include(m => m.Style.BackgroundMesh.ColourPoints)
				.SingleOrDefaultAsync(m => m.UniqueName == postWithUniqueName.Item2);

			if (page == null)
			{
				return BadRequest();
			}
			else
			{
				page.Posts.AddLast(post);
			}
			await _context.SaveChangesAsync();
			return Ok(post.Id);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Page>> Delete(long id)
		{
			var page = new Page()
			{
				Id = id
			};
			_context.Pages.Remove(page);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}