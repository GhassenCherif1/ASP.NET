using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TP3Context _context;
        public CustomerController(TP3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(p=> p.MembershipType).Include(p=>p.Movies).ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
