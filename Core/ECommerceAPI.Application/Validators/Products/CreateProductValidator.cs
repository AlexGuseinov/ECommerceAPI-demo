using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
  public class CreateProductValidator : AbstractValidator<VM_Create_Product>
  {
    public CreateProductValidator()
    {
      RuleFor(p => p.Name)
        .NotEmpty()
        .NotNull()
            .WithMessage("Please leave a name for a product")
        .MaximumLength(150)
        .MinimumLength(1)
            .WithMessage("Please insert a product name with 150-1 characters!!");

      RuleFor(p => p.Stock)
        .NotEmpty()
        .NotNull()
            .WithMessage("Please don't leave stock information empty!!")
        .Must(s => s >= 0)
            .WithMessage("Stock information must be more than 0(zero)!!");

      RuleFor(p => p.Price)
        .NotEmpty()
        .NotNull()
            .WithMessage("Please don't leave price information empty!!")
        .Must(s => s >= 0)
            .WithMessage("Price information must be more than 0(zero)!!");
    }
    public bool beStringCharacters(string strs)
    {
      return !string.IsNullOrEmpty(strs) && strs.All(char.IsLetter);
    }
  }
}
