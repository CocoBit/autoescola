using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Repository.Interfaces
{
    public interface IRepository <T> where T:  IModel
    {
        void Criar(T model);
        void Excluir(T model);
        void Atualizar(T model);

        T Buscar(int id);
        List<T> BuscarTodos();
    }
}
