using System;
using System.Collections.Generic;

namespace ProyectoProgramacion.Models
{
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public int IdRestaurante { get; set; }
        public string Plato { get; set; } = null!;
        public decimal Precio { get; set; }

        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
    }
}
