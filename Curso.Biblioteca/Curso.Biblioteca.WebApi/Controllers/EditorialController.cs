using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialService
    {
        private readonly IEditorialService editorialService;

        public EditorialController(IEditorialService editorialService)
        {
            this.editorialService = editorialService;
        }

        [HttpPost]
        public Task<bool> CreateAsync(CrearEditorialDto entity)
        {
            return editorialService.CreateAsync(entity);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(int id)
        {
            return editorialService.DeleteAsync(id);
        }

        [HttpGet]
        public Task<ICollection<EditorialDto>> GetAllAsync()
        {
            return editorialService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<EditorialDto> GetByIdAsync(int id)
        {
            return editorialService.GetByIdAsync(id);
        }

        [HttpPut]
        public Task<bool> UpdateAsync(int id, CrearEditorialDto entity)
        {
            return editorialService.UpdateAsync(id, entity);
        }
    }
}
