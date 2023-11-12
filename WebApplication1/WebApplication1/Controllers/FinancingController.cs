using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class FinancingController : Controller
    {
        private readonly EventsContext _context;
        public FinancingController(EventsContext context)
        {
            _context = context;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 25;
            var financings = _context.SourcesOfFinancing;
            IEnumerable<SourceOfFinancing> financingsPerPages = financings
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { pageNumber = page, pageSize = pageSize, totalItems = _context.SourcesOfFinancing.Count() };
            FinancingViewModel fvm = new FinancingViewModel { PageInfo = pageInfo, Financings = financingsPerPages };
            return View(fvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SourceOfFinancing financing)
        {
            _context.SourcesOfFinancing.Add(financing);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            SourceOfFinancing financing = _context.SourcesOfFinancing.Find(id);
            if (financing != null)
            {
                return View(financing);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(SourceOfFinancing financing)
        {
            _context.Entry(financing).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            SourceOfFinancing financing = _context.SourcesOfFinancing.Find(id);
            if (financing != null)
            {
                _context.SourcesOfFinancing.Remove(financing);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
