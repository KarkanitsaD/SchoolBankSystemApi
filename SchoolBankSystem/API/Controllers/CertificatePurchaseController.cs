using Business.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CertificatePurchaseController : ControllerBase
    {
        [HttpPost("{certificateId}")]
        [Authorize(Policy = Roles.Student)]
        public async Task<IActionResult> Purchase(Guid certificateId)
        {
            return Ok();
        }

        [HttpPost("activate/{purchaseId}")]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> Activate(Guid purchaseId)
        {
            return Ok();
        } 
    }
}
