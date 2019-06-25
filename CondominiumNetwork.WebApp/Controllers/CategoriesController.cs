using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CondominiumNetwork.WebApp.ViewModels;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using CondominiumNetwork.DomainModel.Identity;
using CondominiumNetwork.DomainModel.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using CondominiumNetwork.DomainModel.ValueObjects;

namespace CondominiumNetwork.WebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(ICategoryService categoryService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.ReadAllCategories()));
        }


        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] DbCategory dbCategory, string category)
        {
            if (ModelState.IsValid)
            {
                if (!ModelState.IsValid) return View(dbCategory);

                var categoryMap = _mapper.Map<Category>(dbCategory);

                categoryMap.Description = category;

                await _categoryService.CreateCategory(categoryMap);

                return RedirectToAction(nameof(Index));
            }
            return View(dbCategory);
        }

        //// GET: Categories/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dbCategory = await _context.Categories.FindAsync(id);
        //    if (dbCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(dbCategory);
        //}

        //// POST: Categories/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Category")] DbCategory dbCategory, string currency)
        //{
        //    if (id != dbCategory.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            dbCategory.Category = new Category(currency);
        //            _context.Update(dbCategory);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DbCategoryExists(dbCategory.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(dbCategory);
        //}

        //// GET: Categories/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dbCategory = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (dbCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dbCategory);
        //}

        //// POST: Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var dbCategory = await _context.Categories.FindAsync(id);
        //    _context.Categories.Remove(dbCategory);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DbCategoryExists(Guid id)
        //{
        //    return _context.Categories.Any(e => e.Id == id);
        //}
    }
}
