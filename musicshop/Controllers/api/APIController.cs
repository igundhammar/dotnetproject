/*
 * Code generated and modified by Ida Gundhammar, 2022-03-18, Mittuniversitetet VT22.
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicshop.Data;
using musicshop.Models.API;

namespace musicshop.Controllers.api;

// Specify routing for the api 
[Route("api/")]
[ApiController]
// Create class APIController that extends class ControllerBase
public class APIController : ControllerBase
{
    // Set properties of Music Database to private readonly
    private readonly MusicDb _db;
    // Constructor with Music Database as parameter, set to local property
    public APIController (MusicDb db)
    {
        _db = db;
    }
    
    
    // Albums GET, return all albums as list
    [HttpGet("album")]
    public async Task<List<Album>> GetAlbum()
    {
        return await _db.Albums.ToListAsync();
    }

    // Albums GET by ID, return specific album as list
    [HttpGet("album/{id}")]
    public async Task<List<Album>> GetAlbumById(int id)
    {
        return await _db.Albums.ToListAsync();
    }
    
    
    
    // Artists GET, return all artists as list
    [HttpGet("artist")]
    public async Task<List<Artist>> GetArtist()
    {
        return await _db.Artists.ToListAsync();
    }

    // Artists GET by NAME, return specific artist as list
    [HttpGet("artist/{name}")]
    public async Task<List<Album>> GetArtistByName(string name)
    {
        var query = from album in _db.Albums
            where album.ArtistName == name
            select album;
        return await query.ToListAsync();
    }
}