using AutoMapper;
using Core.DTOs;
using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalCategory : EntityRepo<Category>, IDalCategory
{
    private readonly IMapper _mapper;
    private readonly IDalCategory _dalCategory;
    public DalCategory(NorthwindContext context, IMapper mapper, IDalCategory dalCategory)
        : base(context)
    {
        _mapper = mapper;
        _dalCategory = dalCategory;
    }
    public IQueryable<DtoCategory> GetAll()
    {
        var cat = _dalCategory.GetAll();
        var dtoCat =
            _mapper.Map<IQueryable<Category>,
                IQueryable<DtoCategory>>(cat);
        return dtoCat;
    }
}