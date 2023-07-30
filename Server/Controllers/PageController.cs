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


public class Person
{
	public Person() { }
	public Person(int id, string name) {
		Name = name;
		Id = id;
	}

	public int Id { get; set; }
	public string Name { get; set; }

	public string FetchCargo(int id)
	{
		//query dartabase for cargo
		return "cargo";
	}
	public string FetchAllCargoes(List<int> ids)
	{
		//query dartabase for cargo
		return "cargoes";
	}
}

public class LizardPerson : Person {
	public int TailLength { get; set; }
	public LizardPerson() {
		Name = "lizard man";
	}
}

public class People
{
	public List<Person> Peoples { get; set; }


	public People()
	{

		Peoples = new List<Person>();

		Peoples.Add(new Person(1, "Lorelle"));
		Peoples.Add(new Person { Id = 2, Name = "John" });
		Peoples.Add(new Person { Id = 3, Name = "Mike" });
		Peoples.Add(new Person { Id = 4, Name = "Potato" });
		Peoples.Add(new Person { Id = 5, Name = "Burt" });

		var namesOnly = Peoples.Select(x => x.FetchCargo(x.Id)).ToList();

		var cargoids = Peoples.Select(x => x.Id).ToList();
		new Person().FetchAllCargoes(cargoids);


		//Traditional way of doing the same thing

		var namesOnlyTraditional = new List<string>();

		foreach (var x in Peoples)
		{
			namesOnlyTraditional.Add(x.Name);
		}
	}
}