

using System.Text.Json.Serialization;
namespace Netcore.Domain
{
  public class Carrera
  {
    public int id { get; set; }

    public int facultad { get; set; }
    public string? nombre_carrera { get; set; }
    public string? codigo_carrera { get; set; }
    public DateTime? creado_tmstp { get; set; }
    public DateTime? actualizado_mstp { get; set; }

    public string? estado { get; set; }
  }
}