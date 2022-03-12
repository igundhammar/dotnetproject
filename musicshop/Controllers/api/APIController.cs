using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicshop.Data;
using musicshop.Models.API;

namespace musicshop.Controllers.api;

[Route("api/")]
[ApiController]
public class APIController : ControllerBase
{

    private readonly MusicDb _db;

    public APIController (MusicDb db)
    {
        _db = db;
    }
    
    
    
    // Albums GET
    [HttpGet("album")]
    public async Task<List<Album>> GetAlbum()
    {
        return await _db.Albums.ToListAsync();
    }

    [HttpGet("album/{id}")]
    public async Task<List<Album>> GetAlbumById(int id)
    {
        return await _db.Albums.ToListAsync();
    }
    
    
    
    // Artists GET
    [HttpGet("artist")]
    public async Task<List<Artist>> GetArtist()
    {
        return await _db.Artists.ToListAsync();
    }

    [HttpGet("artist/{name}")]
    public async Task<List<Album>> GetArtistByName(string name)
    {
        var query = from album in _db.Albums
            where album.ArtistName == name
            select album;
        return await query.ToListAsync();
    }
}