namespace UIBlazor.DTOs;
public class DtoShipper
{
    public int ShipperId { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<DtoOrder> Orders { get; } = new List<DtoOrder>();
}