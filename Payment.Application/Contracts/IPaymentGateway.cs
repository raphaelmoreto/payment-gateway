using Payment.Application.StandardReturns;

namespace Payment.Application.Contracts
{
    public interface IPaymentGateway
    {
        Task<GatewayPaymentStandardReturn> ProcessoAsync(decimal quantia, CancellationToken cancellationToken = default);
    }
}
