using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Application.EntityFramework;
using DAL.Application.Interfaces;
using Domain;
using Domain.Identity;
using WebApp.Areas.Identity.Models;

namespace WebApp.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UserRolesController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public UserRolesController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Identity/UserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _uow.IdentityUserRoleRepository.AllAsync());
        }

        // GET: Identity/UserRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRole = await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRole == null)
            {
                return NotFound();
            }

            return View(identityUserRole);
        }

        // GET: Identity/UserRoles/Create
        public IActionResult Create()
        {
            var vm = new UserRolesCreateEditViewModel
            {
                UserSelectList = new SelectList(items: _uow.ApplicationUsers.All(), dataValueField: nameof(ApplicationUser.IdentityUserId),
                    dataTextField: nameof(ApplicationUser.Email)),
                RoleSelectList = new SelectList(items: _uow.IdentityRoleRepository.All(),
                    dataValueField: nameof(IdentityRole.IdentityRoleId), dataTextField: nameof(IdentityRole.Name))

            };
            return View(vm);
        }

        // POST: Identity/UserRoles/Create
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
            vm.UserSelectList = new SelectList(items: _uow.ApplicationUsers.All(), dataValueField: nameof(ApplicationUser.IdentityUserId),
                dataTextField: nameof(ApplicationUser.Email), selectedValue:vm.IdentityUserRole.IdentityUserId);
            vm.RoleSelectList = new SelectList(items: _uow.IdentityRoleRepository.All(),
                dataValueField: nameof(IdentityRole.IdentityRoleId), dataTextField: nameof(IdentityRole.Name), selectedValue:vm.IdentityUserRole.IdentityRoleId);

            return View(vm);
        }

        // GET: Identity/UserRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRole = await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRole == null)
            {
                return NotFound();
            }
            var vm = new UserRolesCreateEditViewModel
            {
                IdentityUserRole = identityUserRole,
                UserSelectList = new SelectList(items: _uow.ApplicationUsers.All(), dataValueField: nameof(ApplicationUser.IdentityUserId),
                    dataTextField: nameof(ApplicationUser.Email)),
                RoleSelectList = new SelectList(items: _uow.IdentityRoleRepository.All(),
                    dataValueField: nameof(IdentityRole.IdentityRoleId), dataTextField: nameof(IdentityRole.Name))

            };
            return View(vm);
        }

        // POST: Identity/UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserRolesCreateEditViewModel vm)
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
                    if (!IdentityUserRoleExists(vm.IdentityUserRole.IdentityUserRoleId))
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
            vm.UserSelectList = new SelectList(items: _uow.ApplicationUsers.All(), dataValueField: nameof(ApplicationUser.IdentityUserId),
                dataTextField: nameof(ApplicationUser.Email), selectedValue: vm.IdentityUserRole.IdentityUserId);
            vm.RoleSelectList = new SelectList(items: _uow.IdentityRoleRepository.All(),
                dataValueField: nameof(IdentityRole.IdentityRoleId), dataTextField: nameof(IdentityRole.Name), selectedValue: vm.IdentityUserRole.IdentityRoleId);

            return View(vm);
        }

        // GET: Identity/UserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUserRole = await _uow.IdentityUserRoleRepository.FindAsync(id);
            if (identityUserRole == null)
            {
                return NotFound();
            }

            return View(identityUserRole);
        }

        // POST: Identity/UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identityUserRole = await _uow.IdentityUserRoleRepository.FindAsync(id);
            _uow.IdentityUserRoleRepository.Remove(identityUserRole);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityUserRoleExists(int id)
        {
            return _uow.IdentityUserRoleRepository.FindAsync(id) != null;
        }
    }
}
