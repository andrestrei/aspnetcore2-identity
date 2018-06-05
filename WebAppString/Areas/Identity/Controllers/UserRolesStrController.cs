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
using WebAppString.Areas.Identity.Models;

namespace WebAppString.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UserRolesStrController : Controller
    {
        private readonly IApplicationUnitOfWorkStr _uow;

        public UserRolesStrController(IApplicationUnitOfWorkStr uow)
        {
            _uow = uow;
        }

        // GET: Identity/UserRolesStr
        public async Task<IActionResult> Index()
        {
            //var applicationDbContextString = _context.IdentityUserRoles.Include(i => i.IdentityRole).Include(i => i.IdentityUser);
            return View(await _uow.IdentityUserRoleRepository.UserRolesFullInfoAsync());
        }

        // GET: Identity/UserRolesStr/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRoleStr = await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRoleStr == null)
            {
                return NotFound();
            }

            return View(identityUserRoleStr);
        }

        // GET: Identity/UserRolesStr/Create
        public IActionResult Create()
        {
            var vm = new UserRolesCreateEditViewModel
            {
                UserSelectList = new SelectList(_uow.IdentityUserRepository.All(), nameof(IdentityUserStr.IdentityUserId), nameof(IdentityUserStr.Email)),
                RoleSelectList = new SelectList(_uow.IdentityRoleRepository.All(), nameof(IdentityRoleStr.IdentityRoleId), nameof(IdentityRoleStr.Name))
            };
            return View(vm);
        }

        // POST: Identity/UserRolesStr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRolesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.IdentityUserRoleRepository.Add(vm.IdentityUserRole);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.UserSelectList = new SelectList(_uow.IdentityUserRepository.All(), nameof(IdentityUserStr.IdentityUserId),
                nameof(IdentityUserStr.Email), selectedValue: vm.IdentityUserRole.IdentityUserId);
            vm.RoleSelectList = new SelectList(_uow.IdentityRoleRepository.All(), nameof(IdentityRoleStr.IdentityRoleId),
                nameof(IdentityRoleStr.Name), selectedValue: vm.IdentityUserRole.IdentityRoleId);

            return View(vm);
        }

        // GET: Identity/UserRolesStr/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRoleStr =  await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRoleStr == null)
            {
                return NotFound();
            }
            var vm = new UserRolesCreateEditViewModel
            {
                IdentityUserRole = identityUserRoleStr,
                UserSelectList = new SelectList(_uow.IdentityUserRepository.All(), nameof(IdentityUserStr.IdentityUserId), nameof(IdentityUserStr.Email)),
                RoleSelectList = new SelectList(_uow.IdentityRoleRepository.All(), nameof(IdentityRoleStr.IdentityRoleId), nameof(IdentityRoleStr.Name))
            };
            return View(vm);
        }

        // POST: Identity/UserRolesStr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserRolesCreateEditViewModel vm)
        {
            if (id != vm.IdentityUserRole.IdentityUserRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.IdentityUserRoleRepository.Update(vm.IdentityUserRole);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityUserRoleStrExists(vm.IdentityUserRole.IdentityUserRoleId))
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
            vm.UserSelectList = new SelectList(_uow.IdentityUserRepository.All(), nameof(IdentityUserStr.IdentityUserId),
                nameof(IdentityUserStr.Email), selectedValue: vm.IdentityUserRole.IdentityUserId);
            vm.RoleSelectList = new SelectList(_uow.IdentityRoleRepository.All(), nameof(IdentityRoleStr.IdentityRoleId),
                nameof(IdentityRoleStr.Name), selectedValue: vm.IdentityUserRole.IdentityRoleId);
            return View(vm);
        }

        // GET: Identity/UserRolesStr/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRoleStr =  await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRoleStr == null)
            {
                return NotFound();
            }

            return View(identityUserRoleStr);
        }

        // POST: Identity/UserRolesStr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var identityUserRoleStr = await _uow.IdentityUserRoleRepository.FindAsync(id);
            _uow.IdentityUserRoleRepository.Remove(identityUserRoleStr);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityUserRoleStrExists(string id)
        {
            return _uow.IdentityUserRoleRepository.FindAsync(id) != null;
        }
    }
}
