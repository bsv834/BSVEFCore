using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BSVEFCore.DBContext;
using BSVEFCore.Models;

namespace BSVEFCore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly BSVDBContext _context;

        public EmployeesController(BSVDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bSVDBContext = _context.Employees.Include(e => e.Departments);
            return View(await bSVDBContext.ToListAsync());
        }
        
        public IActionResult Create()
        {
            ViewData["D_Id"] = new SelectList(_context.Departments, "D_Id", "D_Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("E_Id,E_Name,E_Phone,D_Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.E_Id = Guid.NewGuid();
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["D_Id"] = new SelectList(_context.Departments, "D_Id", "D_Name", employee.D_Id);
            return View(employee);
        }
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["D_Id"] = new SelectList(_context.Departments, "D_Id", "D_Name", employee.D_Id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("E_Id,E_Name,E_Phone,D_Id")] Employee employee)
        {
            if (id != employee.E_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.E_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["D_Id"] = new SelectList(_context.Departments, "D_Id", "D_Name", employee.D_Id);
            return View(employee);
        }
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Departments)
                .FirstOrDefaultAsync(m => m.E_Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Departments)
                .FirstOrDefaultAsync(m => m.E_Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.E_Id == id);
        }
    }
}
