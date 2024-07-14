using CMS.Application.Common.Handling;

namespace CMS.Application.Shared.Validations
{
    public interface IPasswordValidation
    {
        Task<Result<string>> Passwordvalidate();
    }
}
