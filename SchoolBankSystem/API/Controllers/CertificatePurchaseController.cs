using Business.Constants;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatePurchaseController : ControllerBase
    {
        private readonly ICertificatePurchaseService _certificatePurchaseService;

        public CertificatePurchaseController(ICertificatePurchaseService certificatePurchaseService)
        {
            _certificatePurchaseService = certificatePurchaseService;
        }

        [HttpPost("{certificateId}")]
        [Authorize(Policy = Roles.Student)]
        public async Task<IActionResult> Purchase(Guid certificateId)
        {
            var result = await _certificatePurchaseService.PurchaseAsync(certificateId);

            return Ok(result);
        }

        [HttpPost("activate/{purchaseId}")]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> Activate(Guid purchaseId)
        {
            var result = await _certificatePurchaseService.ActivateAsync(purchaseId);

            return Ok(result);
        } 
    }
}
