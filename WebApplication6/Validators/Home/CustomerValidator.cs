using App.Web.Models;
using FluentValidation;

namespace App.Web.Validators.Home
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim gerekli");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girilmeli");
        }
    }
}
