using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface IEditorialService
    {
        Task<ICollection<EditorialDto>> GetAllAsync();
        Task<EditorialDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CrearEditorialDto entity);
        Task<bool> CreateAsync(CrearEditorialDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
