using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Application.EFString;
using DAL.Application.Interfaces;
using Domain.Identity;

namespace WebAppString.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UsersStrController : Controller
    {
        private readonly IApplicationUnitOfWorkStr _uow;

        public UsersStrController(IApplicationUnitOfWorkStr uow)
        {
            _uow = uow;
        }

        // GET: Identity/UsersStr
        public async Task<IActionResult> Index()
        {
            return View(await _uow.IdentityUserRepository.AllAsync());
        }

        // GET: Identity/UsersStr/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserStr = await _uow.IdentityUserRepository.FindAsync(id);
            if (identityUserStr == null)
            {
                return NotFound();
            }

            return View(identityUserStr);
        }

        // GET: Identity/UsersStr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identity/UsersStr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityUserStr identityUserStr)
        {
            identityUserStr.ConcurrencyStamp = Guid.NewGuid().ToString();
            identityUserStr.SecurityStamp = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                _uow.IdentityUserRepository.Add(identityUserStr);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identityUserStr);
        }

        // GET: Identity/UsersStr/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserStr = await _uow.IdentityUserRepository.FindAsync(id);
            if (identityUserStr == null)
            {
                return NotFound();
            }
            return View(identityUserStr);
        }

        // POST: Identity/UsersStr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityUserStr identityUserStr)
        {
            if (id != identityUserStr.IdentityUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.IdentityUserRepository.Update(identityUserStr);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityUserStrExists(identityUserStr.IdentityUserId))
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
            return View(identityUserStr);
        }

        // GET: Identity/UsersStr/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserStr = await _uow.IdentityUserRepository.FindAsync(id);
            if (identityUserStr == null)
            {
                return NotFound();
            }

            return View(identityUserStr);
        }

        // POST: Identity/UsersStr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var identityUserStr = await _uow.IdentityUserRepository.FindAsync(id);
            _uow.IdentityUserRepository.Remove(identityUserStr);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityUserStrExists(string id)
        {
            return _uow.IdentityUserRepository.FindAsync(id) != null;
        }
    }
}
