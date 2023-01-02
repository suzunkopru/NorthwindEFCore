using DataAccess.Interfaces;
namespace DataAccess.Classes;
public class DALBaglan : IOrnek
{
    private readonly DalSqlOrnek _dalSqlOrnek;
    //private readonly DalPstOrnek _dalPstOrnek;
    public DALBaglan()
    {
        _dalSqlOrnek = new DalSqlOrnek();
        //_dalPstOrnek = new DalPstOrnek();
    }
    public string Get() => _dalSqlOrnek.Get();
    //public string Get() => _dalPstOrnek.Get();
}
