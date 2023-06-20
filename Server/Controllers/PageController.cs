using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HybridPages.Server.Data;
using HybridPages.Shared.Models;
using System.Security.Claims;
using AutoMapper;

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
                .Include(m => m.Posts)
                .SingleOrDefaultAsync(m => m.UniqueName == uniqueName);
            return Ok(page);
        }
        [HttpPost]
        public async Task<ActionResult<long>> Add(Page page)
        {
            var existingPage = await GetPage(page.UniqueName);

			if (existingPage == null)
            {
				page.UserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault();
				var userProfile = _context.UserProfiles.First(u => u.UserId == page.UserId);
				_context.Attach(userProfile);
				page.CreatorId = userProfile.Id;
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