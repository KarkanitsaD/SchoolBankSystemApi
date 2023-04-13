using Business.Constants;
using Business.Models.Certificate;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = Roles.Teacher)]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _service;

        public CertificateController(ICertificateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCertificateModel model)
        {
            var result = await _service.AddCertificateAsync(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CertificateModel model)
        {
            var result = await _service.UpdateCertificateAsync(model);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteCertificateAsync(id);

            return Ok();
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetAllAsync(CertificateFilterModel filterModel)
        {
            var result = await _service.GetAllAsync(filterModel);

            return Ok(result);
        }
    }
}
