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
	public class PageController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private IMapper _mapper;
		public PageController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		[HttpGet("{uniqueName}")]
		public async Task<ActionResult<Page>> GetPage(string uniqueName)
		{
			var page = await _context.Pages
				.Include(m => m.PageMeta)
				.Include(m => m.Posts.OrderBy(p => Convert.ToInt32(p.PostMeta.Single(pm => pm.Key == PostMetaEnum.Order.ToString()).Value)))
				.ThenInclude(p => p.PostMeta)
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

				await Add(page);
			}
			return Ok(page);
		}

		[HttpPost]
		public async Task<ActionResult<long>> Add(Page page)
		{
			var existingPage = await _context.Pages
				.Include(m => m.PageMeta)
				.Include(m => m.Posts)
				.SingleOrDefaultAsync(m => m.UniqueName == page.UniqueName);

			var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault();
			var userProfile = _context.UserProfiles.First(u => u.UserId == userId);
			page.UserProfileId = userProfile.Id;

			var i = 0;
			var orderKey = PostMetaEnum.Order.ToString();

			foreach (var post in page.Posts)
			{
				var orderEntry = post.PostMeta.SingleOrDefault(o => o.Key == orderKey);

				if (orderEntry == null)
				{
					var newOrderEntry = new PostMeta { Key = orderKey, PostId = post.Id, Value = i.ToString() };
					post.PostMeta.Add(newOrderEntry);
				}
				else if (orderEntry.Value != i.ToString())
				{
					orderEntry.Value = i.ToString();
				}

				i++;
			}

			if (existingPage == null)
			{
				_context.Pages.Add(page);
			}
			else
			{
				_mapper.Map(page, existingPage);
			}
			await _context.SaveChangesAsync();
			return Ok(page.Id);
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