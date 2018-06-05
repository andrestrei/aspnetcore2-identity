using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Application.EntityFramework;
using DAL.Application.Interfaces;
using Domain.Identity;

namespace WebApp.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RolesController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public RolesController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Identity/Roles
        public async Task<IActionResult> Index()
        {
            return View(await _uow.IdentityRoleRepository.AllAsync());
        }

        // GET: Identity/Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRole == null)
            {
                return NotFound();
            }

            return View(identityRole);
        }

        // GET: Identity/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identity/Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            identityRole.ConcurrencyStamp = Guid.NewGuid().ToString();
            identityRole.NormalizedName = identityRole.Name.ToUpper();
            if (ModelState.IsValid)
            {
                _uow.IdentityRoleRepository.Add(identityRole);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identityRole);
        }

        // GET: Identity/Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRole == null)
            {
                return NotFound();
            }
            return View(identityRole);
        }

        // POST: Identity/Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IdentityRole identityRole)
        {
            if (id != identityRole.IdentityRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    identityRole.NormalizedName = identityRole.Name.ToUpper();
                    _uow.IdentityRoleRepository.Update(identityRole);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(identityRole.IdentityRoleId))
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
            return View(identityRole);
        }

        // GET: Identity/Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _uow.IdentityRoleRepository.FindAsync(id);
            if (identityRole == null)
            {
                return NotFound();
            }

            return View(identityRole);
        }

        // POST: Identity/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identityRole = await _uow.IdentityRoleRepository.FindAsync(id);
            _uow.IdentityRoleRepository.Remove(identityRole);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _uow.IdentityRoleRepository.FindAsync(id) != null;
        }
    }
}
