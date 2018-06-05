using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Application.EntityFramework;
using DAL.Application.EntityFramework.Repositories;
using DAL.Application.Interfaces;
using Domain;

namespace WebApp.Controllers
{
    public class FooBarsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public FooBarsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: FooBars
        public async Task<IActionResult> Index()
        {
            return View(await _uow.FooBars.AllAsync());
        }

        // GET: FooBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _uow.FooBars.FindAsync(id);
            if (fooBar == null)
            {
                return NotFound();
            }

            return View(fooBar);
        }

        // GET: FooBars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooBars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FooBar fooBar)
        {
            if (ModelState.IsValid)
            {
                _uow.FooBars.Add(fooBar);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fooBar);
        }

        // GET: FooBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _uow.FooBars.FindAsync(id);
            if (fooBar == null)
            {
                return NotFound();
            }
            return View(fooBar);
        }

        // POST: FooBars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FooBarId,FooBarValue")] FooBar fooBar)
        {
            if (id != fooBar.FooBarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.FooBars.Update(fooBar);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooBarExists(fooBar.FooBarId))
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
            return View(fooBar);
        }

        // GET: FooBars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _uow.FooBars.FindAsync(id);
            if (fooBar == null)
            {
                return NotFound();
            }

            return View(fooBar);
        }

        // POST: FooBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fooBar = await _uow.FooBars.FindAsync(id);
            _uow.FooBars.Remove(fooBar);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooBarExists(int id)
        {
            return _uow.FooBars.Find(id) != null;
        }
    }
}
