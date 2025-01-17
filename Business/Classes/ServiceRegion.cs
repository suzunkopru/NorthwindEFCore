﻿using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceRegion
    : Service<Region>, IServiceRegion
{
    public ServiceRegion
        (IEntityRepo<Region> entityRepo) 
                        : base(entityRepo) { }
}