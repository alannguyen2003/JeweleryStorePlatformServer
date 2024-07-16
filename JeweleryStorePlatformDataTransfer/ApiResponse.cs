namespace JeweleryStorePlatformDataTransfer;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public int RoleId { get; set; }
    public object Data { get; set; }
}