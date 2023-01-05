using Autofac;
using Core.Helper;
using DataAccess.Interfaces;
namespace UIWinForms;
internal static class Program
{
    [STAThread] 
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run
            (new frmProduct(
                Configure().Resolve<IDalProduct>(),
                Configure().Resolve<IDalDtoProductCatName>(),
                Configure().Resolve<IDalCategory>(),
                Configure().Resolve<IDalSupplier>(), 
                new MappingProfiles().MatchMap()));
    }
}