namespace AwesomePOS.Models;

public class BillDetail
{
    public int Id { get; set; }
    public int BillMasterId { get; set; }
    public int ProductId { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? Price { get; set;}

}
