namespace AwesomePOS.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; } = 0;
    public decimal VATRate { get; set; } = 0;

    public override string ToString()
    {
        return Name;
    }
}
