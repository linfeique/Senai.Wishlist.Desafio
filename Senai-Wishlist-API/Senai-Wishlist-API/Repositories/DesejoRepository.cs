using Senai.Wishlist.API.Domains;
using Senai.Wishlist.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.API.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        public void Cadastrar(Desejos desejo)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                ctx.Desejos.Add(desejo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Desejos desejo = ctx.Desejos.Find(id);

                ctx.Desejos.Remove(desejo);
                ctx.SaveChanges();
            }
        }

        public List<Desejos> Listar()
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                return ctx.Desejos.ToList();
            }
        }
    }
}
