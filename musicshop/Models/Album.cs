/*
 * Code written by Ida Gundhammar, 2022-03-18, Mittuniversitetet VT22.
 */
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicshop.Models.API;

// Create model for Album
public class Album
{
    public int Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public int Year { get; set; }
    [Required] public string? Genre { get; set; }

    [Display(Name = "Artist Name")] public string? ArtistName { get; set; }

    // FK to Artist table
    public Artist? Artist { get; set; }

    public string? ImagePath { get; set; }

    // Do not store file in database, hence the [NotMapped]
    [NotMapped]
    [Display(Name = "Album Cover")]
    public IFormFile? ImageFile { get; set; }
}