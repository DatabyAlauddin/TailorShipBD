using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TylorShop.Models;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using TylorShop.Models_Customs;

namespace TylorShop.Controllers
{
    public class CustomerInfoesController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CustomerInfoes
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.CustomerInfos.Include(c => c.CreatedByNavigation).Include(c => c.OwnerNavigation).Include(c => c.UpdatedByNavigation);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 50, string searchTerm = null)
        {
            var data = _context.CustomerInfos.OrderByDescending(x => x.Oid).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform case-insensitive search by checking the CustomerName (or any other relevant property)
                data = data.Where(c => c.CustomerName.Contains(searchTerm) || c.ContactNumber.Contains(searchTerm)).OrderByDescending(x => x.Oid);
            }
            //return View(await data.ToListAsync());


            int totalItems = await data.CountAsync();
            var items = await data
                .Skip((pageNumber - 1) * pageSize) // Skip records for previous pages
                .Take(pageSize) // Take only the records for the current page
                .ToListAsync();
            ViewData["CurrentFilteronCustomer"] = searchTerm;
            // Pass data and pagination info to the view
            var viewModel = new PaginatedList<CustomerInfo>(items, totalItems, pageNumber, pageSize);
            return View(viewModel);
        }


        // GET: CustomerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.OwnerNavigation)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // GET: CustomerInfoes/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            return View();
        }

        public IActionResult CreateFromOrderTaking()
        {
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            return View("CreateFromOrderTaking");
        }
        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,CustomerName,ContactNumber,Gender,Age,Address,Lomba,Body,Pet,Put,Hat,Gola,LuzHata,OptimisticLockField,Gcrecord")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.CreatedBy);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.UpdatedBy);
            return View(customerInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromOrderTaking([Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,CustomerName,ContactNumber,Gender,Age,Address,Lomba,Body,Pet,Put,Hat,Gola,LuzHata,OptimisticLockField,Gcrecord")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInfo);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("CreateRouteingCutomer", "OrderTakings", new { CusomerOid = customerInfo.Oid });
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.CreatedBy);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.UpdatedBy);
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.CreatedBy);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.UpdatedBy);
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,CustomerName,ContactNumber,Gender,Age,Address,Lomba,Body,Pet,Put,Hat,Gola,LuzHata,OptimisticLockField,Gcrecord")] CustomerInfo customerInfo)
        {
            if (id != customerInfo.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerInfoExists(customerInfo.Oid))
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
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.CreatedBy);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", customerInfo.UpdatedBy);
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfos
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.OwnerNavigation)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // POST: CustomerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo != null)
            {
                _context.CustomerInfos.Remove(customerInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerInfoExists(int id)
        {
            return _context.CustomerInfos.Any(e => e.Oid == id);
        }
    }
}
