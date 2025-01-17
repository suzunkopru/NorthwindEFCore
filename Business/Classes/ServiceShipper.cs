﻿using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceShipper 
    : Service<Shipper>, IServiceShipper
{
    public ServiceShipper
        (IEntityRepo<Shipper> entityRepo) 
                        : base(entityRepo) { }
}