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
    public class LibroService : ILibroService
    {
        private readonly ILibroRepositorio repositorio;

        public LibroService(ILibroRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<bool> CreateAsync(CrearLibroDto entity)
        {
            var libro = new Libro
            {
                Titulo = entity.Titulo,
                ISBN = entity.ISBN,
                AutorId = entity.AutorId,
                EditorialId = entity.AutorId
            };
            await repositorio.CreateAsync(libro);
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

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consulta = repositorio.GetAll();
            var listaEntitys = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Editorial = x.Editorial.Nombre,
                Autor = $"{x.Autor.Nombre} {x.Autor.Apellido}"
            }).ToListAsync();
            return listaEntitys;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var entity = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Editorial = x.Editorial.Nombre,
                Autor = $"{x.Autor.Nombre} {x.Autor.Apellido}" 
            }).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, CrearLibroDto entity)
        {
            var consulta = repositorio.GetAll();
            consulta = consulta.Where(x => x.Id == id);
            var libro = new Libro
            {
                Id = id,
                Titulo = entity.Titulo,
                ISBN = entity.ISBN,
                AutorId = entity.AutorId,
                EditorialId = entity.EditorialId
            };
            await repositorio.UpdateAsync(libro);
            return true;

        }
    }
}
