using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Infrastructure.Data;
using WitheLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{
	public class VillaController : Controller
	{
		private readonly ApplicationDbContext _context;
		public VillaController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var villas = _context.Villas.ToList();
			return View(villas);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Villa obj)
		{
			if (obj.Name == obj.Description)
			{
				ModelState.AddModelError("name", "The description cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				_context.Villas.Add(obj);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}