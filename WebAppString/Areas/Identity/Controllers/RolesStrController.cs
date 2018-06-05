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
    public class RolesStrController : Controller
    {
        private readonly IApplicationUnitOfWorkStr _uow;

        public RolesStrController(IApplicationUnitOfWorkStr uow)
        {
            _uow = uow;
        }

        // GET: Identity/RolesStr
        public async Task<IActionResult> Index()
        {
            return View(await _uow.IdentityRoleRepository.AllAsync());
        }

        // GET: Identity/RolesStr/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRoleStr = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRoleStr == null)
            {
                return NotFound();
            }

            return View(identityRoleStr);
        }

        // GET: Identity/RolesStr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identity/RolesStr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRoleStr identityRoleStr)
        {
            identityRoleStr.ConcurrencyStamp = Guid.NewGuid().ToString();
            identityRoleStr.NormalizedName = identityRoleStr.Name.ToUpper();
            if (ModelState.IsValid)
            {
                _uow.IdentityRoleRepository.Add(identityRoleStr);
                //_uow.Ide
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identityRoleStr);
        }

        // GET: Identity/RolesStr/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRoleStr = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRoleStr == null)
            {
                return NotFound();
            }
            return View(identityRoleStr);
        }

        // POST: Identity/RolesStr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRoleStr identityRoleStr)
        {
            if (id != identityRoleStr.IdentityRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    identityRoleStr.NormalizedName = identityRoleStr.Name.ToUpper();
                    _uow.IdentityRoleRepository.Update(identityRoleStr);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityRoleStrExists(identityRoleStr.IdentityRoleId))
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
            return View(identityRoleStr);
        }

        // GET: Identity/RolesStr/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRoleStr = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRoleStr == null)
            {
                return NotFound();
            }

            return View(identityRoleStr);
        }

        // POST: Identity/RolesStr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var identityRoleStr = await _uow.IdentityRoleRepository.FindAsync(id);
            _uow.IdentityRoleRepository.Remove(identityRoleStr);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityRoleStrExists(string id)
        {
            return _uow.IdentityRoleRepository.FindAsync(id) != null;
        }
    }
}
