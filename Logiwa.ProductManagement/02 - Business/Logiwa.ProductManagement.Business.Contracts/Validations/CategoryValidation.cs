using FluentValidation;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Core.Validation;

namespace Logiwa.ProductManagement.Business.Contracts.Validations
{
    public class CategoryValidation : Validator<CategoryDto>
    {
        public CategoryValidation()
        {
            ValidateName();
        }

        void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter a valid name for category");
        }
    }
}
