using Autofac;
using Business.Classes;
using Business.Interfaces;
using DataAccess.Interfaces;
namespace UIWinForms;
public static class AutoFacImp
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new();
        builder.RegisterType<ServiceDtoProductCatName>()
                            .As<IServiceDtoProductCatName>();
        builder.RegisterType<DalDtoProductCatName>()
            .As<IDalDtoProductCatName>(); 
        builder.RegisterType<ServiceCategory>()
                            .As<IServiceCategory>();
        builder.RegisterType<ServiceProduct>()
                            .As<IServiceProduct>();
        builder.RegisterType<ServiceSupplier>()
                            .As<IServiceSupplier>();
        builder.RegisterType<ServiceCustomer>()
                            .As<IServiceCustomer>();
        builder.RegisterType<ServiceEmployee>()
                            .As<IServiceEmployee>();
        builder.RegisterType<ServiceOrder>()
                            .As<IServiceOrder>();
        builder.RegisterType<ServiceRegion>()
                            .As<IServiceRegion>();
        builder.RegisterType<ServiceShipper>()
                            .As<IServiceShipper>();
        builder.RegisterType<ServiceTerritory>()
                            .As<IServiceTerritory>();
        builder.RegisterGeneric(typeof(EntityRepo<>))
                            .As(typeof(IEntityRepo<>));
        builder.RegisterType<NorthwindContext>();
        builder.RegisterType<frmCategories>();
        builder.RegisterType<frmProdCatSup>();
        builder.RegisterType<frmProduct>();
        builder.RegisterType<frmSuppliers>();
        return builder.Build();
    }
}