using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TylorShop.Models;

namespace TylorShop.Controllers
{
    public class PermissionPolicyUsersController : Controller
    {
        private readonly AppDbContext _context;

        public PermissionPolicyUsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return RedirectToAction("Home", "Home"); // Redirect to Home if already logged in
            }
            return View("Login");
        }

        // Authenticate User 
        [HttpPost]
        public IActionResult Authenticate(string UserName, string StoredPassword)
        {
            var checkUserListisEmptyorNot = _context.PermissionPolicyUsers.Count();
            if (checkUserListisEmptyorNot == 0)
            {
                PermissionPolicyUser NewUser = new PermissionPolicyUser();
                NewUser.Oid = Guid.NewGuid();
                NewUser.UserName = "admin";
                NewUser.StoredPassword = "1122";
                NewUser.IsActive = true;
            }
            var user = _context.PermissionPolicyUsers
                .FirstOrDefault(u => u.UserName == UserName && u.StoredPassword == StoredPassword &&  (u.IsActive ?? false));

            if (user != null )
            {
                if (user.UserName != null)
                {
                    HttpContext.Session.SetString("UserName", user.UserName);
                    return RedirectToAction("Home", "Home"); 
                }
                 
               
            }

            ViewBag.Message = "Invalid username or password."; // Display error message
            return View("Login");
        }

        // Logout Action
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear the session
            return RedirectToAction("Login", "PermissionPolicyUsers");
        }







        // GET: PermissionPolicyUsers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PermissionPolicyUsers.Include(p => p.ObjectTypeNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PermissionPolicyUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionPolicyUser = await _context.PermissionPolicyUsers
                .Include(p => p.ObjectTypeNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (permissionPolicyUser == null)
            {
                return NotFound();
            }

            return View(permissionPolicyUser);
        }

        // GET: PermissionPolicyUsers/Create
        public IActionResult Create()
        {
            PermissionPolicyUser newUser = new PermissionPolicyUser();
            newUser.Oid = Guid.NewGuid();

            ViewData["ObjectType"] = new SelectList(_context.XpobjectTypes, "Oid", "Oid");
            return View(newUser);
        }

        // POST: PermissionPolicyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoredPassword,ChangePasswordOnFirstLogon,UserName,IsActive,OptimisticLockField,Gcrecord,ObjectType")] PermissionPolicyUser permissionPolicyUser)
        {
            if (ModelState.IsValid)
            {
                //permissionPolicyUser.Oid = Guid.NewGuid();
                _context.Add(permissionPolicyUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjectType"] = new SelectList(_context.XpobjectTypes, "Oid", "Oid", permissionPolicyUser.ObjectType);
            return View(permissionPolicyUser);
        }

        // GET: PermissionPolicyUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionPolicyUser = await _context.PermissionPolicyUsers.FindAsync(id);
            if (permissionPolicyUser == null)
            {
                return NotFound();
            }
            ViewData["ObjectType"] = new SelectList(_context.XpobjectTypes, "Oid", "Oid", permissionPolicyUser.ObjectType);
            return View(permissionPolicyUser);
        }

        // POST: PermissionPolicyUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Oid,StoredPassword,ChangePasswordOnFirstLogon,UserName,IsActive,OptimisticLockField,Gcrecord,ObjectType")] PermissionPolicyUser permissionPolicyUser)
        {
            if (id != permissionPolicyUser.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissionPolicyUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionPolicyUserExists(permissionPolicyUser.Oid))
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
            ViewData["ObjectType"] = new SelectList(_context.XpobjectTypes, "Oid", "Oid", permissionPolicyUser.ObjectType);
            return View(permissionPolicyUser);
        }

        // GET: PermissionPolicyUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionPolicyUser = await _context.PermissionPolicyUsers
                .Include(p => p.ObjectTypeNavigation)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (permissionPolicyUser == null)
            {
                return NotFound();
            }

            return View(permissionPolicyUser);
        }

        // POST: PermissionPolicyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var permissionPolicyUser = await _context.PermissionPolicyUsers.FindAsync(id);
            if (permissionPolicyUser != null)
            {
                _context.PermissionPolicyUsers.Remove(permissionPolicyUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionPolicyUserExists(Guid id)
        {
            return _context.PermissionPolicyUsers.Any(e => e.Oid == id);
        }
    }
}
