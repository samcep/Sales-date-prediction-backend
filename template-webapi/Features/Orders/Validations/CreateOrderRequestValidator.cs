using FluentValidation;
using template_webapi.Features.Orders.Dtos;
public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.Empid)
            .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");

        RuleFor(x => x.Custid)
            .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

        RuleFor(x => x.Shipperid)
            .GreaterThan(0).WithMessage("Shipper ID must be greater than zero.");

        RuleFor(x => x.Shipname)
            .NotEmpty().WithMessage("Ship name is required.");

        RuleFor(x => x.Shipaddress)
            .NotEmpty().WithMessage("Ship address is required.");

        RuleFor(x => x.Shipcity)
            .NotEmpty().WithMessage("Ship city is required.");

        RuleFor(x => x.Shipcountry)
            .NotEmpty().WithMessage("Ship country is required.");

        RuleFor(x => x.Orderdate)
            .NotEmpty().WithMessage("Order date is required.");

        RuleFor(x => x.Requireddate)
            .GreaterThanOrEqualTo(x => x.Orderdate)
            .WithMessage("Required date must be equal to or later than order date.");

        RuleFor(x => x.Freight)
            .GreaterThanOrEqualTo(0).WithMessage("Freight must be zero or positive.");

        RuleFor(x => x.Productid)
            .GreaterThan(0).WithMessage("Product ID must be greater than zero.");

        RuleFor(x => x.Unitprice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero.");

        RuleFor(x => x.Qty)
            .GreaterThan((short)0).WithMessage("Quantity must be greater than zero.");

    }
}
