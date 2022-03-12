using System.ComponentModel.DataAnnotations;

namespace musicshop.Models.API;

public class Album
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string? Genre { get; set; }
    
    [Display(Name="Artist Name")]
    public string? ArtistName { get; set; }

    public Artist? Artist { get; set; }



}