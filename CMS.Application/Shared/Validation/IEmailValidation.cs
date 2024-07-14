using CMS.Application.Common.Handling;

namespace CMS.Application.Shared.Validations
{
    public interface IEmailValidation
    {
        Task<Result<string>> Emailvalidate();
    }
}
