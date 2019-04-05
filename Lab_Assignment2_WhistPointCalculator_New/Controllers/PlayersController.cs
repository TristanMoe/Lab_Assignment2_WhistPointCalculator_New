﻿using System.Linq;
using System.Threading.Tasks;
using Lab_Assignment2_WhistPointCalculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab_Assignment2_WhistPointCalculator_New.Controllers
{
    public class PlayersController : Controller
    {
        private readonly DataContext _dbContext;

        public PlayersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Players.ToListAsync());
        }

        public async Task<IActionResult> AddPlayer([Bind("FirstName,LastName")] Players playerModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(playerModel);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Game");
            }
            return View(playerModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstsName,LastName")] Players playerModel)
        {
            if (id != playerModel.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(playerModel);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicantModelExists(playerModel.PlayerId))
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
            return View(playerModel);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _dbContext.Players
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplicantModel = await _dbContext.Players.FindAsync(id);
            _dbContext.Players.Remove(jobApplicantModel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicantModelExists(int id)
        {
            return _dbContext.Players.Any(e => e.PlayerId == id);
        }
    }
}