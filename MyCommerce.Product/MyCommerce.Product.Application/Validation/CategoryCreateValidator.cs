using FluentValidation;
using MyCommerce.Product.Application.Commands;

namespace MyCommerce.Product.Application.Validation
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateCommand>
    {
        public CategoryCreateValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name alanı boş geçilemez!");
        }
    }
}