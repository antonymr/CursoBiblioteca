using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorService
    {
        private readonly IAutorService autorService;

        public AutorController(IAutorService autorService)
        {
            this.autorService = autorService;
        }

        [HttpPost]
        public Task<bool> CreateAsync(CrearAutorDto entity)
        {
            return autorService.CreateAsync(entity);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(int id)
        {
            return autorService.DeleteAsync(id);
        }

        [HttpGet]
        public Task<ICollection<AutorDto>> GetAllAsync()
        {
            return autorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<AutorDto> GetByIdAsync(int id)
        {
            return autorService.GetByIdAsync(id);
        }

        [HttpPut]
        public Task<bool> UpdateAsync(int id, CrearAutorDto entity)
        {
            return autorService.UpdateAsync(id, entity);
        }
    }
}
