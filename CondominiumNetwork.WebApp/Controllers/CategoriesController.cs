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
using System.Linq;
using static CondominiumNetwork.WebApp.Extensions.CustomAuthorization;

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

        [ClaimsAuthorize("Category", "List")]
        public async Task<IActionResult> Index()
        {
            var listCategories = await _categoryService.ReadAllCategories();

            IList<DbCategory> listDbCategory = new List<DbCategory>();
            foreach (Category item in listCategories)
            {
                DbCategory list = new DbCategory();
                list.Category = item;
                listDbCategory.Add(list);
            }

            return View(listDbCategory.ToList());
        }

        [ClaimsAuthorize("Category", "Add")]
        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Category", "Add")]
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
    }
}
