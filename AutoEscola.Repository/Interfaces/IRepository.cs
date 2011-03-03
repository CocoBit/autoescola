using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Repository.Interfaces
{
    public interface IRepository <T> where T:  IModel
    {
        void Create(T model);
        void Delete(T model);
        void Update(T model);

        T Find(int id);
        List<T> All();
    }
}
