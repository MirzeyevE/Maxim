
using Maxim.DAL;
using Maxim.Models;
using Maxim.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maxim.Controllers
{
    public class HomeController : Controller
    {
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
        {
			_context = context;
		}
        public async Task<IActionResult> Index()
        {
            List<Service> Services = await _context.Services.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Service = Services,
            };
            return View(homeVM);
        }

       
    }
}