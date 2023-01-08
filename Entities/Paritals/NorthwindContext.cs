using Microsoft.EntityFrameworkCore;
namespace Entities.Paritals;
public partial class NorthwindContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies(false);
}
