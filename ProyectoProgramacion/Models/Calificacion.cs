using System;
using System.Collections.Generic;

namespace ProyectoProgramacion.Models
{
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdRestaurante { get; set; }
        public string Comentario { get; set; } = null!;
        public int Puntaje { get; set; }

        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
