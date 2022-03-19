/*
 * Code generated and modified by Ida Gundhammar, 2022-03-18, Mittuniversitetet VT22.
 */
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using musicshop.Data;
using musicshop.Models.API;

namespace musicshop.Controllers
{
    // Create class AlbumController that extends class Controller
    public class AlbumController : Controller
    {
        // Set properties of Music Database and IWebHostEnvironment to private readonly
        private readonly MusicDb _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        // Constructor with Music Database and IWebHostEnvironment as parameters, set to local properties
        public AlbumController(MusicDb context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        // GET: Album
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            // Adds a search-function to the Index page of Albums. If the searchString contains letters, filter the database with query and return results in list
            if (!String.IsNullOrEmpty(searchString))
            {
                var cDCollectionContext = _context.Albums.Include(a => a.Artist)
                    .Where(s => s.Name!.ToLower().Contains(searchString.ToLower()));
                return View(await cDCollectionContext.ToListAsync());
            }
            // If the searchbar is empty or null, return all results from database in list
            else
            {
                var cDCollectionContext = _context.Albums.Include(a => a.Artist);
                return View(await cDCollectionContext.ToListAsync());
            }
        }

        // GET: Album/Details/5
        [Authorize]
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
        [Authorize]
        public IActionResult Create()
        {
            // Put Selectlist with all ArtistNames in ViewData
            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Genre,ArtistName,ImageFile")] Album album)
        {
            if (ModelState.IsValid)
            {
                // If imageFile is not null, get path to wwwroot-folder and get fileName from uploaded file.
                if (album.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(album.ImageFile.FileName);

                    // Set album imagePath to the fileName.
                    album.ImagePath = fileName;

                    // Save full path to image in folder
                    string path = Path.Combine(wwwRootPath + "/images/" + fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await album.ImageFile.CopyToAsync(fileStream);
                    }
                }
                else
                // If the imageFile is null, use default image in wwwroot-folder 
                {
                    album.ImagePath = "album.jpg";
                }

                // Add new album to database
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // 
            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View(album);
        }

        // GET: Album/Edit/5
        [Authorize]
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
            // Put Selectlist with all ArtistNames in ViewData
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
                    // Try block that executes whether the imageFile of the album is edited or not.
                    if (album.ImageFile != null)

                    {
                        // If the imageFile is not null on editing the album, that means the user uploaded a new image of the album. Execute as usual, same as under CREATE
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
                    // If the imageFile is null, that means the user probably wants to keep the already existing image of the album. Find the fileName of the existing image in the database with a query,
                    // set properties in to new variable of the album from the database and update the album with new properties (but keep the existing image).
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
                // If the try block fails, catch error here
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            // Put Selectlist with all ArtistNames in ViewData
            ViewData["Artist"] = new SelectList(_context.Artists, "Name", "Name");
            return View(album);
        }

        // GET: Album/Delete/5
        [Authorize]
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
        [Authorize]
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