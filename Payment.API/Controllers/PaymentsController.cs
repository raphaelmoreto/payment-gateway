using Microsoft.AspNetCore.Mvc;
using Payment.Application.DTOs;
using Payment.Application.Services;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public sealed class PaymentsController : ControllerBase
    {
        private readonly ProcessPaymentService processPaymentService;

        public PaymentsController(ProcessPaymentService processPaymentService)
        {
            this.processPaymentService = processPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcessPaymentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await processPaymentService.ExecuteAsync(request, cancellationToken);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
