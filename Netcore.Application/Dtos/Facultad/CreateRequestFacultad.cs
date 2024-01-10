namespace Netcore.Application;

using System.ComponentModel.DataAnnotations;

public class CreateRequestFacultad
{
  [Required]
  [MaxLength(256)]
  public string? nombre_facultad { get; set; }

  [Required]
  [MaxLength(16)]
  public string? codigo_facultad { get; set; }




}