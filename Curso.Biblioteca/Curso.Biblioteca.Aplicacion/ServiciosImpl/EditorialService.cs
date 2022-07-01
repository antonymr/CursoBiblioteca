using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosImpl
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepositorio repositorio;

        public EditorialService(IEditorialRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<bool> CreateAsync(CrearEditorialDto entity)
        {
            var editorial = new Editorial
            {
                Nombre = entity.Nombre,
                Direccion = entity.Direccion
            };
            await repositorio.CreateAsync(editorial);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var entity = consulta.SingleOrDefault();
            await repositorio.DeleteAsync(entity);
            return true;
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaEntitys = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).ToListAsync();
            return listaEntitys;
        }

        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var entity = await consulta.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, CrearEditorialDto entity)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var editorial = new Editorial
            {
                Id = id,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion
            };
            await repositorio.UpdateAsync(editorial);
            return true;

        }
    }
}
