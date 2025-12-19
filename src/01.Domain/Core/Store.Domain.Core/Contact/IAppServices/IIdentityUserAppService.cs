using Store.Domain.Core.Dtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface IIdentityUserAppService
    {
        public Task<ResultDto<bool>> UpdateIdentity(int identityId, string Username, string email);
        public Task<ResultDto<bool>> UpdatePassword(int identityId, string oldpass, string newpass);
    }
}
