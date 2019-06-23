using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondominiumNetwork.WebApp.Data;
using CondominiumNetwork.WebApp.ViewModels;

namespace CondominiumNetwork.WebApp.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfileViewModel.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ProfileViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileViewModel == null)
            {
                return NotFound();
            }

            return View(profileViewModel);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthday,BlockApartment,PhotoUrl")] ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                profileViewModel.Id = Guid.NewGuid();
                _context.Add(profileViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileViewModel);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ProfileViewModel.FindAsync(id);
            if (profileViewModel == null)
            {
                return NotFound();
            }
            return View(profileViewModel);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Birthday,BlockApartment,PhotoUrl")] ProfileViewModel profileViewModel)
        {
            if (id != profileViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileViewModelExists(profileViewModel.Id))
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
            return View(profileViewModel);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ProfileViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileViewModel == null)
            {
                return NotFound();
            }

            return View(profileViewModel);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profileViewModel = await _context.ProfileViewModel.FindAsync(id);
            _context.ProfileViewModel.Remove(profileViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileViewModelExists(Guid id)
        {
            return _context.ProfileViewModel.Any(e => e.Id == id);
        }
    }
}
