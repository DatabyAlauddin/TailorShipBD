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
    public class OrderTakingsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderTakingsController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult Home()
        //{
        //    return View();
        //}
        // GET: OrderTakings
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.OrderTakings.Include(o => o.CreatedByNavigation).Include(o => o.CustomerNavigation).Include(o => o.OwnerNavigation).Include(o => o.UpdatedByNavigation);
        //    return View(await appDbContext.ToListAsync());
        //}


        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 50, string searchTerm = null)
        {
            // Fetch the data
            var data = _context.OrderTakings.Include(o => o.CustomerNavigation).OrderByDescending(x=>x.Oid).AsQueryable();



            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform case-insensitive search by checking the CustomerName (or any other relevant property)
                data = data.Where(c => c.CustomerNavigation != null && (c.CustomerNavigation.CustomerName.Contains(searchTerm)||c.CustomerNavigation.ContactNumber.Contains(searchTerm) )).OrderByDescending(x=>x.Oid);
            }

            // Calculate the total number of pages
            int totalItems = await data.CountAsync();
            var items = await data
                .Skip((pageNumber - 1) * pageSize) // Skip records for previous pages
                .Take(pageSize) // Take only the records for the current page
                .ToListAsync();
            ViewData["CurrentFilter"] = searchTerm;
            // Pass data and pagination info to the view
            var viewModel = new PaginatedList<OrderTaking>(items, totalItems, pageNumber, pageSize);
            return View(viewModel);
        }






        // GET: OrderTakings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTaking = await _context.OrderTakings
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.CustomerNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.UpdatedByNavigation)
                 .Include(o => o.OrderTransactions)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderTaking == null)
            {
                return NotFound();
            }

            return View("PrintableDetail",orderTaking);
        }

        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTaking = await _context.OrderTakings
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.CustomerNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.UpdatedByNavigation)
                 .Include(o => o.OrderTransactions)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderTaking == null)
            {
                return NotFound();
            }

            return View("PrintableDetail", orderTaking);
        }

        // GET: OrderTakings/Create
        public IActionResult Create()
        {
            ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "DisplayText");
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            //ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "CustomerName");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid");
            return View();
        }

        // POST: OrderTakings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,Customer,OrderDate,DelevaryDate,Discription,DiscriptionPant,DiscriptionKamiz,EkChata,EkCharaJubba,Kabli,Serwani,Fotua,JubbaKalidar,Shart,Borka,Koti,Kalider,Aligori,Lomba,Body,Pet,Put,Hat,Gola,LuzHata,Kolar,Plet,Hata,Nic,NocShohoFara,NicThekeFara,PocketThekeBondo,Pocket,Paipen,Selwar,Cosh,Curidar,Naro,Pant,PantPocket,CouraRabar,CikonRabar,MobilePocket,IsReady,IsDelevered,IsCancelled,Amount,Discount,OptimisticLockField,Gcrecord")] OrderTaking orderTaking)
        {
            
            if (ModelState.IsValid)
            {

                orderTaking.OrderDate = DateTime.Today;
                orderTaking.CreatedAt = DateTime.Now;

                _context.Add(orderTaking);
                await _context.SaveChangesAsync();
                //ViewBag.OrderOid = orderTaking.Oid;

                //ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.CreatedBy);
                ////ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "Oid", orderTaking.Customer);
                //ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "DisplayText");
                //ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.Owner);
                //ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.UpdatedBy);

                //return View(orderTaking);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.CreatedBy);
            //ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "Oid", orderTaking.Customer);
            ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "DisplayText");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.UpdatedBy);
            return View(orderTaking);
        }

       

        [HttpGet]
        public JsonResult GetCustomerAttributes(int selectedId)
        {
            var customer = _context.CustomerInfos.FirstOrDefault(c => c.Oid == selectedId);

            if (customer == null)
            {
                return Json(new { error = "Customer not found" });
            }

            // Example data, you can modify based on your needs
            var attributes = new
            {
                lomba = customer.Lomba,
                body = customer.Body,
                pet = customer.Pet,
                put = customer.Put,
                hat = customer.Hat,
                gola = customer.Gola,
                luzhata = customer.LuzHata
            };

            return Json(attributes);
        }

        [HttpGet]
        public IActionResult SearchCustomers(string searchTerm)
        {
            var customers = _context.CustomerInfos
                .Where(c => c.CustomerName.Contains(searchTerm) || c.ContactNumber.Contains(searchTerm))
                .Select(c => new
                {
                    id = c.Oid,
                    name = c.CustomerName,
                    contactNumber = c.ContactNumber
                })
                .ToList();

            return Json(customers);
        }

       


        // GET: OrderTakings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTaking = await _context.OrderTakings.Include(o => o.OrderTransactions).FirstOrDefaultAsync(m => m.Oid == id); ;
            if (orderTaking == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.CreatedBy);
            //ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "Oid", orderTaking.Customer);
            ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "DisplayText");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.UpdatedBy);
            return View(orderTaking);
        }

        // POST: OrderTakings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Owner,CreatedAt,UpdateAt,CreatedBy,UpdatedBy,IsActive,Customer,OrderDate,DelevaryDate,Discription,DiscriptionPant,DiscriptionKamiz,EkChata,EkCharaJubba,Kabli,Serwani,Fotua,JubbaKalidar,Shart,Borka,Koti,Kalider,Aligori,Lomba,Body,Pet,Put,Hat,Gola,LuzHata,Kolar,Plet,Hata,Nic,NocShohoFara,NicThekeFara,PocketThekeBondo,Pocket,Paipen,Selwar,Cosh,Curidar,Naro,Pant,PantPocket,CouraRabar,CikonRabar,MobilePocket,IsReady,IsDelevered,IsCancelled,Amount,Discount,OptimisticLockField,Gcrecord")] OrderTaking orderTaking)
        {
            if (id != orderTaking.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTaking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTakingExists(orderTaking.Oid))
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
            ViewData["CreatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.CreatedBy);
            //ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "Oid", orderTaking.Customer);
            ViewData["Customer"] = new SelectList(_context.CustomerInfos, "Oid", "DisplayText");
            ViewData["Owner"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.Owner);
            ViewData["UpdatedBy"] = new SelectList(_context.EmployeeMasters, "Oid", "Oid", orderTaking.UpdatedBy);
            return View(orderTaking);
        }

        // GET: OrderTakings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTaking = await _context.OrderTakings
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.CustomerNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderTaking == null)
            {
                return NotFound();
            }

            return View(orderTaking);
        }

        // POST: OrderTakings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderTaking = await _context.OrderTakings.FindAsync(id);
            if (orderTaking != null)
            {
                _context.OrderTakings.Remove(orderTaking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTakingExists(int id)
        {
            return _context.OrderTakings.Any(e => e.Oid == id);
        }
    }
}
