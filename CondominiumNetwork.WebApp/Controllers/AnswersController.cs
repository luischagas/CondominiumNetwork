using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CondominiumNetwork.WebApp.ViewModels;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using CondominiumNetwork.DomainModel.Identity;
using CondominiumNetwork.DomainModel.Entities;
using Microsoft.AspNetCore.Http;

namespace CondominiumNetwork.WebApp.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswersController(IAnswerService answerService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _answerService = answerService;
            _mapper = mapper;
            _userManager = userManager;
        }


        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<OcurrenceViewModel>>(await _answerService.GetAll()));
        }

        private async Task<IEnumerable<AnswerViewModel>> GetAnswersOcurrence(Guid id)
        {
            return _mapper.Map<IEnumerable<AnswerViewModel>>(await _answerService.GetAnswersOcurrence(id));
        }

        //GET: Answers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerViewModel = await GetAnswersOcurrence(id);

            if (answerViewModel == null)
            {
                return NotFound();
            }

            return View(answerViewModel);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PublishDateTime,Content,OcurrenceId,ProfileId")] AnswerViewModel answerViewModel)
        {
            ApplicationUser usr = await GetCurrentUserAsync();

            var currentUserGuid = Guid.Parse(usr.Id);

            if (currentUserGuid == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(answerViewModel);

            var answer = _mapper.Map<Answer>(answerViewModel);

            answer.ProfileId = currentUserGuid;
            answer.OcurrenceId = Guid.Parse(HttpContext.Session.GetString("OcurrenceId"));
            answer.PublishDateTime = DateTime.Now;

            await _answerService.Create(answer);

            var url = Url.Action("GetOcurrenceAnswers", "Ocurrences", new { id = answer.Id });
            return Json(new { success = true, url });
        }

        public async Task<IActionResult> CreateAnswer()
        {
            return PartialView("_CreateAnswer");
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //// GET: Answers/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var answerViewModel = await _context.AnswerViewModel.FindAsync(id);
        //    if (answerViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(answerViewModel);
        //}

        //// POST: Answers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,PublishDateTime,Content,OcurrenceId,ProfileId")] AnswerViewModel answerViewModel)
        //{
        //    if (id != answerViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(answerViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AnswerViewModelExists(answerViewModel.Id))
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
        //    return View(answerViewModel);
        //}

        //// GET: Answers/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var answerViewModel = await _context.AnswerViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (answerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(answerViewModel);
        //}

        //// POST: Answers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var answerViewModel = await _context.AnswerViewModel.FindAsync(id);
        //    _context.AnswerViewModel.Remove(answerViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AnswerViewModelExists(Guid id)
        //{
        //    return _context.AnswerViewModel.Any(e => e.Id == id);
        //}
    }
}
