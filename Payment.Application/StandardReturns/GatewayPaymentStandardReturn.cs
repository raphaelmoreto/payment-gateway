
namespace Payment.Application.StandardReturns
{
    public sealed record GatewayPaymentStandardReturn(bool IsApproved, string? IdTransacao, string? Mensagem);
}
