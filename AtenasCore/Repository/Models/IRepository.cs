using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> ListarTodos();
        T PesquisarPorId(int id);
        T Adicionar(T item);
        T Modificar(T item);
        bool Excluir(int id);
    }
}
