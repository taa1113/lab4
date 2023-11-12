using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EventsContext _context;
        public EmployeesController(EventsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 25;
            var employees = _context.Employees.ToList();
            IEnumerable<Employee> employeesPerPages = employees
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { pageNumber = page, pageSize = pageSize, totalItems = _context.Employees.Count() };
            EmployeesViewModel evm = new EmployeesViewModel { PageInfo = pageInfo, Employees = employeesPerPages };
            return View(evm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
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
            Employee employee = _context.Employees.Find(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("HttpNotFound");
            }
            Employee employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
