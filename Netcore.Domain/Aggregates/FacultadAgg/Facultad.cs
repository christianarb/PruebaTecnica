

using System.Text.Json.Serialization;

namespace Netcore.Domain
{ 
public class Facultad
{
  public int? id { get; set; }
  public string? nombre_facultad { get; set; }
  public string? codigo_facultad { get; set; }
  public DateTime? creado_tmstp { get; set; }
  public DateTime? actualizado_tmstp { get; set; }

  public string? estado { get; set; }
}
}