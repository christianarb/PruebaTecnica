namespace Netcore.Application;

using System.ComponentModel.DataAnnotations;


public class CreateRequestCarrera
{

  [Required]

  public int? facultad { get; set; }

  [Required]
  [MaxLength(256)]
  public string? nombre_carrera{ get; set; }

  [Required]
  [MaxLength(16)]
  public string? codigo_carrera { get; set; }
}