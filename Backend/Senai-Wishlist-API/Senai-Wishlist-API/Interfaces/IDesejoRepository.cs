﻿using Senai.Wishlist.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.API.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejos> Listar();

        void Cadastrar(Desejos desejo);

        void Deletar(int id);
    }
}
