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
using static CondominiumNetwork.WebApp.Extensions.CustomAuthorization;

namespace CondominiumNetwork.WebApp.Controllers
{
    [Authorize]
    public class WarningsController : Controller
    {
        private readonly IWarningService _warningService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public WarningsController(IWarningService warningService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _warningService = warningService;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Warnings
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<WarningViewModel>>(await _warningService.GetAll()));
        }

        // GET: Warnings/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var warningViewModel = await GetDetailsWarning(id);

            if (warningViewModel == null)
            {
                return NotFound();
            }

            return View(warningViewModel);
        }

        [ClaimsAuthorize("Warning","Add")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Warning", "Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublishDateTime,Content")] WarningViewModel warningViewModel)
        {
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(warningViewModel);

            var warning = _mapper.Map<Warning>(warningViewModel);

            warning.ProfileId = currentUserGuid;

            warning.PublishDateTime = DateTime.Now;

            await _warningService.Create(warning);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Warning", "Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var warningViewModel = await GetDetailsWarning(id);

            if (warningViewModel == null)
            {
                return NotFound();
            }

            return View(warningViewModel);
        }

        [ClaimsAuthorize("Warning", "Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PublishDateTime,Content")] WarningViewModel warningViewModel)
        {
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (id != warningViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(warningViewModel);

            var warning = _mapper.Map<Warning>(warningViewModel);

            warning.ProfileId = currentUserGuid;
            warning.PublishDateTime = DateTime.Now;

            await _warningService.Update(warning);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Warning", "Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var warningViewModel = await GetDetailsWarning(id);

            if (warningViewModel == null)
            {
                return NotFound();
            }

            return View(warningViewModel);
        }

        [ClaimsAuthorize("Warning", "Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
             var warningViewModel = await GetDetailsWarning(id);

            if (warningViewModel == null) return NotFound();

            await _warningService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<WarningViewModel> GetDetailsWarning(Guid id)
        {
            return _mapper.Map<WarningViewModel>(await _warningService.GetDetailsWarning(id));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
