namespace AwesomePOS.Models;

public class BillDetail
{
    public int Id { get; set; }
    public int BillMasterId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; } = 1;
    public decimal Price { get; set; } = 0;
    public decimal VatRate { get; set; } = 0;

}

