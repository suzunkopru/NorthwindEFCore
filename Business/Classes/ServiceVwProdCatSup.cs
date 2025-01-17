﻿using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceVwProdCatSup : 
        Service<VwProdCatSup>, IServiceVwProdCatSup
{
    public ServiceVwProdCatSup
        (IEntityRepo<VwProdCatSup> entityRepo) 
                        : base(entityRepo) { }
}