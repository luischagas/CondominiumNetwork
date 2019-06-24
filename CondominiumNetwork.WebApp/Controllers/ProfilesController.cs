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
using Profile = CondominiumNetwork.DomainModel.Entities.Profile;

namespace CondominiumNetwork.WebApp.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilesController(IProfileService profileService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _profileService = profileService;
            _mapper = mapper;
            _userManager = userManager;
        }



        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProfileViewModel>>(await _profileService.GetAll()));
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var profileViewModel = await GetProfileOcurrences(id);

            if (profileViewModel == null)
            {
                return NotFound();
            }

            return View(profileViewModel);
        }

        //GET: Profiles/Create
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
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(profileViewModel);

            var profile = _mapper.Map<Profile>(profileViewModel);

            profile.Id = currentUserGuid;

            await _profileService.Create(profile);

            return RedirectToAction("Details", new { @id = currentUserGuid });

        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var profileViewModel = await GetProfileOcurrences(id);

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
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (id != profileViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(profileViewModel);

            var profile = _mapper.Map<Profile>(profileViewModel);
            await _profileService.Update(profile);

            return RedirectToAction("Details", new { @id = currentUserGuid });
        }

        private async Task<ProfileViewModel> GetProfileOcurrences(Guid id)
        {
            return _mapper.Map<ProfileViewModel>(await _profileService.GetProfileOcurrences(id));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
