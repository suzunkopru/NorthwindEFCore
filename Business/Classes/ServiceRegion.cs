﻿using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceRegion : Service<Region>, IServiceRegion
{
    public ServiceRegion(NorthwindContext context)
                            : base(context) { }
}