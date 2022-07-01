using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface IAutorService
    {
        Task<ICollection<AutorDto>> GetAllAsync();
        Task<AutorDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CrearAutorDto entity);
        Task<bool> CreateAsync(CrearAutorDto  entity);
        Task<bool> DeleteAsync(int id);
    }
}
