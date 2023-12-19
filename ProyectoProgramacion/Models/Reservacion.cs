using System;
using System.Collections.Generic;

namespace ProyectoProgramacion.Models
{
    public partial class Reservacion
    {
        public int IdReservacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdRestaurante { get; set; }
        public DateTime FechaReservacion { get; set; }

        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
