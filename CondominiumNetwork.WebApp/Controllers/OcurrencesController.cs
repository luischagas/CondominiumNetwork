﻿using System;
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

namespace CondominiumNetwork.WebApp.Controllers
{
    [Authorize]
    public class OcurrencesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IOcurrenceService _ocurrenceService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public OcurrencesController(IMapper mapper, IOcurrenceService ocurrenceService, ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            _ocurrenceService = ocurrenceService;
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Ocurrences
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<OcurrenceViewModel>>(await _ocurrenceService.GetAllOcurrenceAnswers()));
        }

        // GET: Ocurrences/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var ocurrenceViewModel = await GetDetailsOcurrence(id);

            HttpContext.Session.SetString("OcurrenceId", Convert.ToString(id));

            if (ocurrenceViewModel == null)
            {
                return NotFound();
            }

            return View(ocurrenceViewModel);
        }

        public async Task<IActionResult> GetOcurrenceAnswers(Guid id)
        {
            var ocurrence = await GetDetailsOcurrence(id);

            if (ocurrence == null)
            {
                return NotFound();
            }

            return PartialView("_AnswersOcurrence", ocurrence);
        }

        // GET: Ocurrences/Create
        public IActionResult Create()
        {
            var categories = _categoryService.ReadAllCategories().Result;
         
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Ocurrences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublishDateTime,Content,Category")] OcurrenceViewModel ocurrenceViewModel)
        {
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(ocurrenceViewModel);

            var ocurrence = _mapper.Map<Ocurrence>(ocurrenceViewModel);

            ocurrence.ProfileId = currentUserGuid;

            ocurrence.PublishDateTime = DateTime.Now;

            await _ocurrenceService.Create(ocurrence);

            return RedirectToAction(nameof(Index));

        }

        // GET: Ocurrences/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var ocurrenceViewModel = await GetDetailsOcurrence(id);

            if (ocurrenceViewModel == null)
            {
                return NotFound();
            }

            return View(ocurrenceViewModel);
        }

        // POST: Ocurrences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PublishDateTime,Content,Category")] OcurrenceViewModel ocurrenceViewModel)
        {

            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (id != ocurrenceViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(ocurrenceViewModel);

            var ocurrence = _mapper.Map<Ocurrence>(ocurrenceViewModel);

            ocurrence.ProfileId = currentUserGuid;
            ocurrence.PublishDateTime = DateTime.Now;

            await _ocurrenceService.Update(ocurrence);

            return RedirectToAction(nameof(Index));
        }

        // GET: Ocurrences/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var ocurrenceViewModel = await GetDetailsOcurrence(id);

            if (ocurrenceViewModel == null)
            {
                return NotFound();
            }

            return View(ocurrenceViewModel);
        }

        // POST: Ocurrences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ocurrenceViewModel = await GetDetailsOcurrence(id);

            if (ocurrenceViewModel == null) return NotFound();

            await _ocurrenceService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<OcurrenceViewModel> GetDetailsOcurrence(Guid id)
        {
            return _mapper.Map<OcurrenceViewModel>(await _ocurrenceService.GetOcurrenceAnswers(id));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
