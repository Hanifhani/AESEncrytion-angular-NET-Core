namespace PaymentGateway.Models
{
    public class TransactionModel
    {
        public string? ProcessingCode { get; set; }
        public string? SystemTrace { get; set; }
        public string? FunctionCode { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public decimal TransactionAmount { get; set; }

        public int CurrencyCode { get; set; }
    }
}
