using Payment.Application.Contracts;
using Payment.Application.DTOs;
using Payment.Application.StandardReturns;
using Payment.Domain.Entities;

namespace Payment.Application.Services
{
    public sealed class ProcessPaymentService
    {
        private readonly IPaymentGateway gateway;

        public ProcessPaymentService(IPaymentGateway gateway)
        {
            this.gateway = gateway;
        }

        public async Task<ProcessPaymentResult> ExecuteAsync(ProcessPaymentRequest request, CancellationToken cancellationToken = default)
        {
            var payment = new PaymentEntity(request.Quantia);

            var gatewayResult = await this.gateway.ProcessoAsync(payment.Quantia, cancellationToken);
            if (gatewayResult.IsApproved)
            {
                payment.Aprovar();
            }
            else
            {
                payment.Rejeitar();
            }

            return new ProcessPaymentResult
            (
                payment.Id, 
                payment.Quantia, 
                payment.Status, 
                gatewayResult.IdTransacao, 
                gatewayResult.Mensagem
            );
        }
    }
}
