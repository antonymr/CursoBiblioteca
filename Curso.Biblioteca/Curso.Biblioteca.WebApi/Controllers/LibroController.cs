using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroService
    {
        private readonly ILibroService libroService;

        public LibroController(ILibroService libroService)
        {
            this.libroService = libroService;
        }

        [HttpPost]
        public Task<bool> CreateAsync(CrearLibroDto entity)
        {
            return libroService.CreateAsync(entity);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(int id)
        {
            return libroService.DeleteAsync(id);
        }

        [HttpGet]
        public Task<ICollection<LibroDto>> GetAllAsync()
        {
            return libroService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<LibroDto> GetByIdAsync(int id)
        {
            return libroService.GetByIdAsync(id);
        }

        [HttpPut]
        public Task<bool> UpdateAsync(int id, CrearLibroDto entity)
        {
            return libroService.UpdateAsync(id, entity);
        }
    }
}
