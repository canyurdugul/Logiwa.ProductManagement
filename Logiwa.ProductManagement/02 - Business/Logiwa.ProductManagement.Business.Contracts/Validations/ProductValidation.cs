using FluentValidation;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Core.Validation;

namespace Logiwa.ProductManagement.Business.Contracts.Validations
{
    public class ProductValidation : Validator<ProductDto>
    {
        private int MinimumStockQuantity = 0;

        public ProductValidation(int minimumStockQuantity)
        {
            this.MinimumStockQuantity = minimumStockQuantity;
            ValidateTitle();
            ValidateCategory();
            ValidateMinimumStockQuantity();
        }

        void ValidateTitle()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .WithMessage("Please enter valid product name");
        }
        void ValidateCategory()
        {
            RuleFor(x => x.CategoryId)

                .NotNull()
                .Must(x => x > 0)
                .WithMessage("Please select category for this product");
        }
        void ValidateMinimumStockQuantity()
        {
            RuleFor(x => x.StockQuantity)
                .GreaterThan(this.MinimumStockQuantity)
                .WithMessage(string.Format("If you want to see this product in selected category, minimum stock quantity needs to be {0}", this.MinimumStockQuantity));
        }
    }
}
