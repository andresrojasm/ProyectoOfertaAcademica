using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From.Entities
{
    public class Usuario
{
    public int cedula { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }
    public int edad { get; set; }
    public string correo { get; set; }
    public string clave { get; set; }
    public string codigoDocente { get; set; }
    public DateTime fechaCreacion { get; set; }
    public int rol { get; set; }
    public bool activo { get; set; }
}