namespace UIBlazor.DTOs;
public class DtoTerritory
{
    public string TerritoryId { get; set; }
    public string TerritoryDescription { get; set; }
    public int RegionId { get; set; }
    public virtual DtoRegion Region { get; set; }
}