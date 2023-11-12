using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class PlanningController : Controller
    {
        private readonly EventsContext _context;
        public PlanningController(EventsContext context)
        {
            _context = context;
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 25;
            var plannedEvents = _context.PlannedEvents.Include(e => e.Enterprise).Include(e => e.Event).Include(e => e.Responsible).Include(e => e.Finance);
            IEnumerable<PlannedEvent> eventsPerPages = plannedEvents
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { pageNumber = page, pageSize = pageSize, totalItems = _context.PlannedEvents.Count() };
            PlanningViewModel pvm = new PlanningViewModel { PageInfo = pageInfo, PlannedEvents = eventsPerPages };
            return View(pvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList events = new(_context.Events, "Id", "Name");
            SelectList enterprises = new(_context.Enterprises, "Id", "Name");
            SelectList employees = new(_context.Employees, "Id", "Surname");
            SelectList financings = new(_context.SourcesOfFinancing, "Id", "Id");
            ViewBag.Events = events;
            ViewBag.Enterprises = enterprises;
            ViewBag.Employees = employees;
            ViewBag.SourcesOfFinancing = financings;
            return View();
        }

        [HttpPost]
        public ActionResult Create(PlannedEvent plannedEvent)
        {
            _context.PlannedEvents.Add(plannedEvent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            PlannedEvent plannedEvent = _context.PlannedEvents.Find(id);
            if(plannedEvent != null) 
            {
                SelectList events = new(_context.Events, "Id", "Name");
                SelectList enterprises = new(_context.Enterprises, "Id", "Name");
                SelectList employees = new(_context.Employees, "Id", "Surname");
                SelectList financings = new(_context.SourcesOfFinancing, "Id", "Id");
                ViewBag.Events = events;
                ViewBag.Enterprises = enterprises;
                ViewBag.Employees = employees;
                ViewBag.SourcesOfFinancing = financings;
                return View(plannedEvent);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(PlannedEvent plannedEvent)
        {
            _context.Entry(plannedEvent).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            PlannedEvent plannedEvent = _context.PlannedEvents.Find(id);
            if (plannedEvent != null)
            {
                _context.PlannedEvents.Remove(plannedEvent);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}