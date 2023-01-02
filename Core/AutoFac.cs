using Autofac;
using DataAccess.Classes;
using DataAccess.Interfaces;
using Entities.Context;
using UIWinForms;
using IContainer = System.ComponentModel.IContainer;

namespace Core;
public static class AutoFac
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new();
        builder.RegisterType<DalProduct>().As<IDalProduct>();
        builder.RegisterType<frmProduct>();
        builder.RegisterType<NorthwindContext>();
        return builder.Build();
    }
}