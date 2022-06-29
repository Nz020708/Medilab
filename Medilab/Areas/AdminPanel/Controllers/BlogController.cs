using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medilab.DAL;
using Medilab.Models;
using Medilab.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Medilab.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Medilab.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env { get; }
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: AdminPanel/Blog
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        // GET: AdminPanel/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: AdminPanel/Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Blog/Create
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Doctor doctors)
        {
            //if (!doctors.Photo.ContentType.Contains("image/"))
            //{
            //    ModelState.AddModelError("Photo", "Type of file must be an image");
            //    return View();
            //}
            if (!ModelState.IsValid)
            {
                return View();
              
            }
            doctors.Image = await doctors.Photo.SaveFileAsync(_env.WebRootPath, "assets", "img");
            await _context.Doctors.AddAsync(doctors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        // GET: AdminPanel/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }
        // POST: AdminPanel/Blog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Doctor doctor)
        {
            //if (!doctor.Photo.ContentType.Contains("image/"))
            //{
            //    ModelState.AddModelError("Photo", "Type of file must be an image");
            //}
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id ==null)
            {
                return BadRequest();
            }
            Doctor doctordb = _context.Doctors.Find(id);
            if (doctordb == null)
            {
                return NotFound();
            }
            doctor.Image = await doctor.Photo.SaveFileAsync(_env.WebRootPath,"assets","img");
            var pathDb = Helper.GetPath(_env.WebRootPath,"assets","img",doctordb.Image);
            if (System.IO.File.Exists(pathDb))
            {
                System.IO.File.Delete(pathDb);
            }
            doctordb.Title = doctor.Title;
            doctordb.Subtitle = doctor.Subtitle;
            doctordb.Description = doctor.Description;
            doctordb.Image = doctor.Image;
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: AdminPanel/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: AdminPanel/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Doctor doctordb = _context.Doctors.Find(id);
            var pathDb = Helper.GetPath(_env.WebRootPath, "assets", "img", doctordb.Image);

            if (System.IO.File.Exists(pathDb))
            {
                System.IO.File.Delete(pathDb);
            }
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
