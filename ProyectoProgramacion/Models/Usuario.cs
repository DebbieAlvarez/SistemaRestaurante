using System;
using System.Collections.Generic;

namespace ProyectoProgramacion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificacions = new HashSet<Calificacion>();
            Reservacions = new HashSet<Reservacion>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
