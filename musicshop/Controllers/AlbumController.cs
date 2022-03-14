#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using musicshop.Data;
using musicshop.Models.API;

namespace musicshop.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MusicDb _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AlbumController(MusicDb context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var cDCollectionContext = _context.Albums.Include(a => a.Artist)
                    .Where(s => s.Name!.ToLower().Contains(searchString.ToLower()));
                return View(await cDCollectionContext.ToListAsync());
            }
            else
            {
                var cDCollectionContext = _context.Albums.Include(a => a.Artist);
                return View(await cDCollectionContext.ToListAsync());
            }
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Genre,ArtistName,ImageFile")] Album album)
        {
            if (ModelState.IsValid)
            {
                if (album.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(album.ImageFile.FileName);

                    album.ImagePath = fileName;

                    string path = Path.Combine(wwwRootPath + "/images/" + fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await album.ImageFile.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    album.ImagePath = "album.jpg";
                }

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Genre,ArtistName,ImageFile")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (album.ImageFile != null)

                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileName(album.ImageFile.FileName);

                        album.ImagePath = fileName;

                        string path = Path.Combine(wwwRootPath + "/images/" + fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await album.ImageFile.CopyToAsync(fileStream);
                        }

                        _context.Update(album);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var getAlbum = await _context.Albums
                            .FirstAsync(m => m.Id == id);
                        getAlbum.Name = album.Name;
                        getAlbum.Year = album.Year;
                        getAlbum.Genre = album.Genre;
                        getAlbum.ArtistName = album.ArtistName;

                        _context.Update(getAlbum);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }
    }
}