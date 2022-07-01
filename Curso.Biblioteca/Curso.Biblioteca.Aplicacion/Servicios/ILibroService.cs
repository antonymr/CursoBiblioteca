using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface ILibroService
    {
        Task<ICollection<LibroDto>> GetAllAsync();
        Task<LibroDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CrearLibroDto entity);
        Task<bool> CreateAsync(CrearLibroDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
