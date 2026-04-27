using ApiProject.WebAPI.Entities;
using FluentValidation;

namespace ApiProject.WebAPI.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez!");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalı!");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalı!");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!").GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan büyük olmalı").LessThan(1000).WithMessage("Ürün Fiyatı 1000'den küçük olmalı!");
            RuleFor(p => p.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
        }
    }
}
