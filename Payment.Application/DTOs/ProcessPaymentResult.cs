using Payment.Domain.Enums;

namespace Payment.Application.DTOs
{
    public sealed record ProcessPaymentResult
    (
        Guid IdPayment, 
        decimal Quantia,
        ePaymentStatus Status, 
        string? IdTransacao, 
        string? Mensagem
    );
}
