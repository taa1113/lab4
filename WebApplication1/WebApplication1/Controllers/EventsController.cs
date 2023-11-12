using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsContext _context;
        public EventsController(EventsContext context)
        {
            _context = context;
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 25;
            var events = _context.Events;
            IEnumerable<Event> eventsPerPages = events
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { pageNumber = page, pageSize = pageSize, totalItems = _context.Events.Count() };
            EventsViewModel evm = new EventsViewModel { PageInfo = pageInfo, Events = eventsPerPages };
            return View(evm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event Event)
        {
            _context.Events.Add(Event);
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
            Event Event = _context.Events.Find(id);
            if (Event != null)
            {
                return View(Event);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Event Event)
        {
            _context.Entry(Event).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            Event Event = _context.Events.Find(id);
            if (Event != null)
            {
                _context.Events.Remove(Event);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
