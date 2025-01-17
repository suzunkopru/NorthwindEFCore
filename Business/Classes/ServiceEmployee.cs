﻿using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceEmployee
    : Service<Employee>, IServiceEmployee
{
    public ServiceEmployee
        (IEntityRepo<Employee> entityRepo) 
                            : base(entityRepo) { }
}