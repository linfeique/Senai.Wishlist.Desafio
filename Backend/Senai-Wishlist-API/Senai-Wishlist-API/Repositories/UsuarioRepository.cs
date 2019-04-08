using Senai.Wishlist.API.Domains;
using Senai.Wishlist.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
                return usuarioProcurado;
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuarios usuarioProc = ctx.Usuarios.Find(id);

                if (usuarioProc == null)
                {
                    return null;
                }

                return usuarioProc;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                ctx.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Find(id);

                ctx.Usuarios.Remove(usuarioProcurado);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
