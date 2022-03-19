/*
 * Code written by Ida Gundhammar, 2022-03-18, Mittuniversitetet VT22.
 */

using System.ComponentModel.DataAnnotations;

namespace musicshop.Models.API;

// Create model for Artist
public class Artist
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

}