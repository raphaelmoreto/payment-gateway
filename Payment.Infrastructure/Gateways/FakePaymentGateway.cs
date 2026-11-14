using Payment.Application.Contracts;
using Payment.Application.StandardReturns;

namespace Payment.Infrastructure.Gateways
{
    public sealed class FakePaymentGateway : IPaymentGateway
    {
        public Task<GatewayPaymentStandardReturn> ProcessoAsync(decimal quantia, CancellationToken cancellationToken = default)
        {
            // VERIFICA SE O CANCELAMENTO DA OPERAÇÃO FOI SOLICITADO. CASO POSITIVO, INTERROMPE A EXECUÇÃO IMEDIATAMENTE LANÇANDO UMA EXCEÇÃO DO TIPO "OperationCanceledException"
            cancellationToken.ThrowIfCancellationRequested();

            var result = quantia <= 1000
                ? new GatewayPaymentStandardReturn
                         (
                            IsApproved: true,
                            IdTransacao: Guid.NewGuid().ToString("N"),
                            Mensagem: "PAGAMENTO APROVADO PELA SIMULAÇÃO"
                         )
                : new GatewayPaymentStandardReturn
                         (
                            IsApproved: false,
                            IdTransacao: null,
                            Mensagem: "VALOR RECUSADO PELA REGRA DE SIMULAÇÃO"
                         );

            return Task.FromResult ( result );
        }
    }
}
