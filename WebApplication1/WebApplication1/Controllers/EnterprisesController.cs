using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class EnterprisesController : Controller
    {
        private readonly EventsContext _context;
        public EnterprisesController(EventsContext context)
        {
            _context = context;
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 25;
            var enterprises = _context.Enterprises.Include(e => e.Manager).Include(e => e.CPE);
            IEnumerable<Enterprise> enterprisesPerPages = enterprises
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { pageNumber = page, pageSize = pageSize, totalItems = _context.Enterprises.Count() };
            EnterprisesViewModel evm = new EnterprisesViewModel { PageInfo = pageInfo, Enterprises = enterprisesPerPages };
            return View(evm);
        }
    }
}
