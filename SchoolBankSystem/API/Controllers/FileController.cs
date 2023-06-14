using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using File = DAL.Entities.File;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IRepository<File> _repository;

        public FileController(IRepository<File> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> File(Guid id)
        {
            var result = await _repository.GetFirstAsync(x => x.Id == id);
            return new FileContentResult(result.Content, result.Extension);
        }
    }
}
