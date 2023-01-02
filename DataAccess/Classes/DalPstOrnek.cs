using DataAccess.Interfaces;
namespace DataAccess.Classes;
public class DalPstOrnek : IOrnek
{
    public string Get()
            => "Ben PostgreSQL ile çalışırım";
}