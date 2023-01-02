namespace UIBlazor.DTOs;
public class DtoCategory
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public byte[] Picture { get; set; }
    public virtual ICollection<DtoProduct> Products { get; } = new List<DtoProduct>();
}