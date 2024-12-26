using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TylorShop.Models;
using TylorShop.Models_Customs;

namespace TylorShop.Controllers
{
    public class OrderTransactionsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderTransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderTransactions
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.OrderTransactions.Include(o => o.CreatedByNavigation).Include(o => o.OrderNavigation).Include(o => o.OwnerNavigation).Include(o => o.UpdatedByNavigation).OrderByDescending(x=>x.Oid);
        //    return View(await appDbContext.ToListAsync());
        //}


        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 50, string searchTerm = null)
        {
            // Fetch the data
            var data = _context.OrderTransactions.Include(o => o.CreatedByNavigation).Include(o => o.OrderNavigation).Include(o => o.OwnerNavigation).Include(o => o.UpdatedByNavigation).OrderByDescending(x => x.Oid);



            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform case-insensitive search by checking the CustomerName (or any other relevant property)
                data = data.Where(c =>  c.Order.ToString() == searchTerm).OrderByDescending(x => x.CreatedAt);
            }

            // Calculate the total number of pages
            int totalItems = await data.CountAsync();
            var items = await data
                .Skip((pageNumber - 1) * pageSize) // Skip records for previous pages
                .Take(pageSize) // Take only the records for the current page
                .ToListAsync();
            ViewData["CurrentFilterforTransaction"] = searchTerm;
            // Pass data and pagination info to the view
            var viewModel = new PaginatedList<OrderTransaction>(items, totalItems, pageNumber, pageSize);
            return View(viewModel);
        }

        // GET: OrderTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTransactions
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.OrderNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderTransaction == null)
            {
                return NotFound();
            }

            return View(orderTransaction);
        }

        // GET: OrderTransactions/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["Order"] = new SelectList(_context.OrderTakings, "Oid", "Oid");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            return View();
        }

        // POST: OrderTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,Order,Amount,TransactionType,OptimisticLockField,Gcrecord")] OrderTransaction orderTransaction)
        {
            if (ModelState.IsValid)
            {
                orderTransaction.CreatedAt = DateTime.Now;
                _context.Add(orderTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.CreatedBy);
            ViewData["Order"] = new SelectList(_context.OrderTakings, "Oid", "Oid", orderTransaction.Order);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.UpdatedBy);
            return View(orderTransaction);
        }

        [HttpGet]
        public IActionResult Create2(int? Order)
        {
            if (Order == null)
            {
                return NotFound();
            }

            var transaction = new OrderTransaction
            {

                Order = Order // Set the OrderOid as default
            };
            ViewBag.Order = new SelectList(_context.OrderTakings, "Oid", "Oid",Order);
            return View("Create", transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,Order,Amount,TransactionType,OptimisticLockField,Gcrecord")] OrderTransaction orderTransaction)
        {
            if (ModelState.IsValid)
            {
                
                
                _context.Add(orderTransaction);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Create", "OrderTakings", new { oid = orderTransaction.Oid });
                return RedirectToAction("Edit", "OrderTakings", new { id = orderTransaction.Order });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.CreatedBy);
            ViewData["Order"] = new SelectList(_context.OrderTakings, "Oid", "Oid", orderTransaction.Order);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.UpdatedBy);
            return View("Create",orderTransaction);
        }




        // GET: OrderTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTransactions.FindAsync(id);
            if (orderTransaction == null)
            {
                return NotFound();
            }
            orderTransaction.Active = orderTransaction.IsActive ?? false;
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.CreatedBy);
            ViewData["Order"] = new SelectList(_context.OrderTakings, "Oid", "Oid", orderTransaction.Order);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.UpdatedBy);
            return View(orderTransaction);
        }

        // POST: OrderTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,Order,Amount,TransactionType,OptimisticLockField,Gcrecord")] OrderTransaction orderTransaction)
        {
            if (id != orderTransaction.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTransactionExists(orderTransaction.Oid))
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
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.CreatedBy);
            ViewData["Order"] = new SelectList(_context.OrderTakings, "Oid", "Oid", orderTransaction.Order);
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTransaction.UpdatedBy);
            return View(orderTransaction);
        }

        // GET: OrderTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTransactions
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.OrderNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderTransaction == null)
            {
                return NotFound();
            }

            return View(orderTransaction);
        }

        // POST: OrderTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderTransaction = await _context.OrderTransactions.FindAsync(id);
            if (orderTransaction != null)
            {
                _context.OrderTransactions.Remove(orderTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTransactionExists(int id)
        {
            return _context.OrderTransactions.Any(e => e.Oid == id);
        }
    }
}
