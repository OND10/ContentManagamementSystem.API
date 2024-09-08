using CMS.Application.Common.Handling;

namespace CMS.Application.Shared.Validations
{
    public interface IPhoneNumberValidation
    {
        Task<Result<string>> PhoneNumbervalidate();
    }
}
