using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondominiumNetwork.WebApp.ViewModels;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CondominiumNetwork.DomainModel.Identity;

namespace CondominiumNetwork.WebApp.Controllers
{
    public class OcurrencesController : Controller
    {
        private readonly IOcurrenceService _fornecedorService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public OcurrencesController(IMapper mapper, IOcurrenceService fornecedorService, UserManager<ApplicationUser> userManager)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Ocurrences
        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await GetCurrentUserAsync();


            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            var ocurrenceViewModel = await GetOcurrencesProfile(currentUserGuid);

            if (ocurrenceViewModel.Count() == 0)
            {
                return NotFound();
            }

            return View(ocurrenceViewModel);
        }

        // GET: Ocurrences/Details/5
        public async Task<IActionResult> Details()
        {
            ApplicationUser usr = await GetCurrentUserAsync();


            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            var ocurrenceViewModel = await GetOcurrencesProfile(currentUserGuid);

            if (ocurrenceViewModel.Count() == 0)
            {
                return NotFound();
            }

            return View(ocurrenceViewModel);
        }

        private async Task<IEnumerable<OcurrenceViewModel>> GetOcurrencesProfile(Guid id)
        {

            return _mapper.Map<IEnumerable<OcurrenceViewModel>>(await _fornecedorService.GetOcurrencesProfile(id));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //// GET: Ocurrences/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ocurrences/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,PublishDateTime,Content,Category")] OcurrenceViewModel ocurrenceViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ocurrenceViewModel.Id = Guid.NewGuid();
        //        _context.Add(ocurrenceViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ocurrenceViewModel);
        //}

        //// GET: Ocurrences/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ocurrenceViewModel = await _context.OcurrenceViewModel.FindAsync(id);
        //    if (ocurrenceViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ocurrenceViewModel);
        //}

        //// POST: Ocurrences/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,PublishDateTime,Content,Category")] OcurrenceViewModel ocurrenceViewModel)
        //{
        //    if (id != ocurrenceViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ocurrenceViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OcurrenceViewModelExists(ocurrenceViewModel.Id))
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
        //    return View(ocurrenceViewModel);
        //}

        //// GET: Ocurrences/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ocurrenceViewModel = await _context.OcurrenceViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ocurrenceViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ocurrenceViewModel);
        //}

        //// POST: Ocurrences/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var ocurrenceViewModel = await _context.OcurrenceViewModel.FindAsync(id);
        //    _context.OcurrenceViewModel.Remove(ocurrenceViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OcurrenceViewModelExists(Guid id)
        //{
        //    return _context.OcurrenceViewModel.Any(e => e.Id == id);
        //}
    }
}
