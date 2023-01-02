using DataAccess.Interfaces;
namespace DataAccess.Classes;
public class DalSqlOrnek : IOrnek
{
    public string Get()
    => "Ben SQL Server ile çalışırım";
}