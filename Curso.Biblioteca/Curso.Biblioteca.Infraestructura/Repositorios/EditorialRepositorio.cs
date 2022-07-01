﻿using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class EditorialRepositorio : IEditorialRepositorio
    {
        private readonly BibliotecaDbContext context;

        public EditorialRepositorio(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Editorial entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<Editorial> GetAll()
        {
            return context.Editoriales.AsQueryable();
        }

        public async Task UpdateAsync(Editorial entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
