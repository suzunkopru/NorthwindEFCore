namespace UIBlazor.DTOs;
public class DtoRegion
{
    public int RegionId { get; set; }
    public string RegionDescription { get; set; }
    public virtual ICollection<DtoTerritory> Territories { get; } = new List<DtoTerritory>();
}