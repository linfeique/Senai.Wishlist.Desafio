using Senai.Wishlist.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.API.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        void Cadastrar(Usuarios usuario);

        void Deletar(int id);

        Usuarios BuscarPorEmailESenha(string email, string senha);

        Usuarios BuscarPorId(int id);
    }
}
