using FluentValidation;
using AbarrotesControl.Core.DTOs;
using System;

namespace AbarrotesControl.Services.Validators
{
    public class ProductoDtoValidator : AbstractValidator<ProductoDto>
    {
        public ProductoDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre no puede superar los 150 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0 (RN-03).");

            RuleFor(x => x.StockMinimo)
                .GreaterThanOrEqualTo(0).WithMessage("El stock mínimo debe ser mayor o igual a 0 (RN-04).");

            RuleFor(x => x.FechaVencimiento)
                .Must(BeValidOrFutureDate).WithMessage("La fecha de vencimiento no puede ser anterior a la fecha actual (RN-05).");
        }

        private bool BeValidOrFutureDate(string? fechaStr)
        {
            if (string.IsNullOrEmpty(fechaStr)) return true;
            if (DateOnly.TryParse(fechaStr, out var fecha))
            {
                return fecha >= DateOnly.FromDateTime(DateTime.Today);
            }
            return false;
        }
    }
}