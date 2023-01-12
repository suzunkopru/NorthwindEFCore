using Autofac;
using Business.Interfaces;
using Core.Helper;
namespace UIWinForms;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run
        (new frmProduct(
            Configure().Resolve<IServiceProduct>(),
            Configure()
                .Resolve<IServiceDtoProductCatName>(),
            Configure().Resolve<IServiceCategory>(),
            Configure().Resolve<IServiceSupplier>(),
            new MappingProfiles().MatchMap()));
    }
}