using Maxim.DAL;
using Maxim.Models;
using Maxim.Utilites.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maxim.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ServicesController : Controller
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServicesController(AppDbContext context,IWebHostEnvironment env)
        {
           _context = context;
           _env = env;
        }
        public async Task<IActionResult> Index()
		{
			List<Service>Services=await _context.Services.ToListAsync();
			return View(Services);
		}
		public async Task<IActionResult>Create(Service ser)
		{
            if (!ModelState.IsValid) return View(ser);
            if (ser.Photo is not null)
            {
                if (!ser.Photo.ValidateType("image/"))
                {
                    ModelState.AddModelError("Photo", "File tipi uyqun deyil");
                    return View(ser);
                }
                if (!ser.Photo.ValidateSize(2 * 1024))
                {
                    ModelState.AddModelError("Photo", "File size uyqun deyil");
                    return View(ser);
                }
            }
            string filename = await ser.Photo.CreateAsync(_env.WebRootPath, "assets", "img", "icons");
            Service services = new Service
            {
                Image = filename,
                Name = ser.Name,
                Description = ser.Description,
            };
            await _context.Services.AddAsync(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
	}
}
