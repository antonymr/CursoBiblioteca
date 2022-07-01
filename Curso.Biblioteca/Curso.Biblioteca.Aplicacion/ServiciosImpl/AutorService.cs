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
    public class AutorService : IAutorService
    {
        private readonly IAutorRepositorio repositorio;

        public AutorService(IAutorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<bool> CreateAsync(CrearAutorDto entity)
        {
            var autor = new Autor
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido
            };
            await repositorio.CreateAsync(autor);
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

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaEntitys = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();
            return listaEntitys;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var entity = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, CrearAutorDto entity)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var autor = new Autor
            {
                Id = id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido
            };
            await repositorio.UpdateAsync(autor);
            return true;

        }
    }
}
