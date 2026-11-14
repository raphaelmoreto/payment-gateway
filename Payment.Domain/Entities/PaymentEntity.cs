using Payment.Domain.Enums;

namespace Payment.Domain.Entities
{
    public sealed class PaymentEntity
    {
        public Guid Id { get; private set; }

        public decimal Quantia { get; private set; }

        public ePaymentStatus Status { get; private set; }

        private PaymentEntity() { }

        public PaymentEntity(decimal quantia)
        {
            if (quantia <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantia), "O VALOR DEVE SER MAIOR QUE ZERO");

            Id = Guid.NewGuid();
            Quantia = quantia;
            Status = ePaymentStatus.PENDENTE;
        }

        public void Aprovar()
        {
            GarantirPagamento();
            Status = ePaymentStatus.APROVADO;
        }

        public void Rejeitar()
        {
            GarantirPagamento();
            Status = ePaymentStatus.REJEITADO;
        }

        private void GarantirPagamento()
        {
            if (Status != ePaymentStatus.PENDENTE)
                throw new InvalidOperationException("SOMENTE PAGAMENTOS PENDENTES PODE SER PROCESSADOS");
        }
    }
}
