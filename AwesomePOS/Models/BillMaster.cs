namespace AwesomePOS.Models;

public class BillMaster
{
    public int Id { get; set; }
    public string? Note { get; set; }
    public decimal? Net { get; set; }
}


public class Bill
{
    public BillMaster? BillMaster { get; set;}
    public BillDetail? BillDetail { get; set;}
}