using FluentValidation;
using MyCommerce.Basket.Application.Commands;

namespace MyCommerce.Basket.Application.Validation
{
    public class CategoryCreateValidator : AbstractValidator<AddToBasketCommand>
    {
        public CategoryCreateValidator()
        {
            RuleFor(m => m.CustomerGuid).NotEmpty().WithMessage("CustomerGuid alanı boş geçilemez!");
        }
    }
}