namespace EquityCalculatorAPI.Models
{
    public class EquityCalculatorModel
    {
        public decimal SellingPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EquityTerm { get; set; }
    }

    public class PaymentInfo
    {
        public int Term { get; set; }
        public decimal Balance { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public decimal Insurance { get; set; }
        public decimal Total { get; set; }
    }
}
