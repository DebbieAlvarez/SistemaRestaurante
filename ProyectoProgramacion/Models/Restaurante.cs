using System;
using System.Collections.Generic;

namespace ProyectoProgramacion.Models
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            Calificacions = new HashSet<Calificacion>();
            Menus = new HashSet<Menu>();
            Reservacions = new HashSet<Reservacion>();
        }

        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Categoria { get; set; } = null!;

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
