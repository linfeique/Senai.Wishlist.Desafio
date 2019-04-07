using System;
using System.Collections.Generic;

namespace Senai.Wishlist.API.Domains
{
    public partial class Desejos
    {
        public int Id { get; set; }
        public string Desejo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
