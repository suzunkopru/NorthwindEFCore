using System.Transactions;
namespace Core.Helper;
public static class TranLevel
{
    public static TransactionScope TranWithNoLock()
    => new TransactionScope(TransactionScopeOption.Required,
       new TransactionOptions()
       {
           IsolationLevel = IsolationLevel.ReadUncommitted
       },
       TransactionScopeAsyncFlowOption.Enabled);
}