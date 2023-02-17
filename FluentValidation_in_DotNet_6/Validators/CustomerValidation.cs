using FluentValidation;
using FluentValidation_in_DotNet_6.Models;

namespace FluentValidation_in_DotNet_6.Validators
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Please enter a name.")
            .Length(2, 50);

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Please enter an email.")
                .EmailAddress()
                .WithMessage("Please enter a valid email address.")
                .Length(5, 100);

            RuleFor(c => c.Age)
                .NotNull()
                .WithMessage("Please enter an age.")
                .InclusiveBetween(18, 120);

            RuleFor(c => c.CreditCard)
                .NotNull()
                .WithMessage("Please enter a credit card number.")
                .CreditCard()
                .WithMessage("Please enter a valid credit card number.");

            RuleFor(c => c.Phone)
                .NotNull()
                .WithMessage("Please enter a phone number.");
               

            RuleFor(c => c.Url)
                .NotEmpty()
                .WithMessage("Please enter a URL.");


            RuleFor(c => c.Status)
                .NotNull()
                .WithMessage("Please select a status.");
                

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Please enter a password.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]")
                .WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]")
                .WithMessage("Password must contain at least one special character.");

            RuleFor(c => c.ConfirmPassword)
                .Equal(c => c.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}