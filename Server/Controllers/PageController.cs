using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HybridPages.Server.Data;
using HybridPages.Shared.Models;
using System.Security.Claims;

namespace HybridPages.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PageController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("getpage/{slug}")]
        public async Task<ActionResult<Page>> GetPage(string pageName)
        {
            var page = await _context.Pages
                .Include(m => m.PageMeta)
                .Include(m => m.Links)
                .SingleAsync(m => m.UniqueName == pageName);
            return Ok(page);
        }
        [HttpPost]
        public async Task<ActionResult<long>> Add(Page page)
        {
            page.UserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault();
            var userProfile = _context.UserProfiles.First(u => u.UserId == page.UserId);
            _context.Attach(userProfile);
            page.CreatorId = userProfile.Id;
            _context.Pages.Add(page);
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