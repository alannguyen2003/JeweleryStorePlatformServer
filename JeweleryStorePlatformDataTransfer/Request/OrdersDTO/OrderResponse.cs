namespace JeweleryStorePlatformDataTransfer.Request.OrdersDTO;

public class OrderResponse
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public string Status { get; set; }
    public string PaymentStatus { get; set; }
    public int Price { get; set; }
}