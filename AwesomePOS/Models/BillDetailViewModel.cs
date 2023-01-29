namespace AwesomePOS.Models
{
    public class BillDetailViewModel
    {
        public int Id { get; set; }
        public int BillMasterId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; } = 1;
        public decimal Price { get; set; } = 0;
        public decimal VatRate { get; set; } = 0;
        public string? ProdactName { get; set; }
        public decimal VatAmt => Price * VatRate;
        public decimal Total
        {
            get
            {
                return Math.Round(Quantity * (Price + VatAmt), 2);
            }
            set
            {
                var singleTotal = value / Quantity;
                Price= singleTotal / (1 + VatRate);
            }
        }
    }
}
