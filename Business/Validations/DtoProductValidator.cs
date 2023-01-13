using Core.DTOs;
using FluentValidation;
namespace Business.Validations;
public class DtoProductValidator : AbstractValidator<DtoProduct>
{
    public DtoProductValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().Length(3, 40);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.ProductId).GreaterThan(0);
    }
    public static string ErrorList(DtoProduct prd)
    {
        DtoProductValidator Validator = new();
        var validation = Validator.Validate(prd);
        string message = "";
        validation.Errors.ForEach(x =>
        {
            message += $"{x.PropertyName} {x.ErrorMessage} \n";
        });
        return message;
    }
}