using Business.Constants;
using Business.Models.MoneyTransfer;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Policy = Roles.Student)]
    [Route("api/[controller]")]
    public class MoneyTransferController : ControllerBase
    {
        private readonly IMoneyTransferService _service;

        public MoneyTransferController(IMoneyTransferService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferMoneyModel transferMoney)
        {
            var result = await _service.TransferMoneyAsync(transferMoney);

            return Ok(result);
        }
    }
}
