using FluentValidation;
using PhoneBook.UI.Models;
using PhoneBook.UI.Utilities.Constants;

namespace PhoneBook.UI.Utilities.Validators
{
    public class ContactViewModelValidator:AbstractValidator<ContactViewModel>
    {
        public  ContactViewModelValidator()
        {
            RuleFor(contact => contact.FirstName).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactFirstName);
            RuleFor(contact => contact.LastName).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactLastName);
            RuleFor(contact => contact.CompanyName).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactCompnayName);
        }
    }
}
