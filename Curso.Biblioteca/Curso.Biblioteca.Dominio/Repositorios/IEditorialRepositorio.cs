using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.Repositorios
{
    public interface IEditorialRepositorio
    {
        IQueryable<Editorial> GetAll();
        Task CreateAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(Editorial editorial);
    }
}
