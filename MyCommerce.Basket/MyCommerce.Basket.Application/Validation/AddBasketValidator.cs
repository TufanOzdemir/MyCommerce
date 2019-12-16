using FluentValidation;
using MyCommerce.Basket.Application.Commands;

namespace MyCommerce.Basket.Application.Validation
{
    public class CategoryCreateValidator : AbstractValidator<AddBasketCommand>
    {
        public CategoryCreateValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name alanı boş geçilemez!");
        }
    }
}