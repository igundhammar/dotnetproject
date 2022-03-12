using System.ComponentModel.DataAnnotations;

namespace musicshop.Models.API;

public class Artist
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

}