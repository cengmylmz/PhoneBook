using FluentValidation;
using PhoneBook.UI.Models;
using PhoneBook.UI.Utilities.Constants;

namespace PhoneBook.UI.Utilities.Validators
{
    public class ContactInfoViewModelValidator : AbstractValidator<ContactInfoViewModel>
    {
        public ContactInfoViewModelValidator()
        {
            RuleFor(contact => contact.EMailAddress).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactInfoEMailAddress);
            RuleFor(contact => contact.EMailAddress).EmailAddress().WithMessage(ValidationErrorMessages.FormatErrorContactInfoEMailAddress);
            RuleFor(contact => contact.PhoneNumber).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactInfoPhoneNumber);
            RuleFor(contact => contact.Location).NotEmpty().WithMessage(ValidationErrorMessages.NotEmptyContactInfoLocation);
        }
    }
}
