using Store.Domain.Core.Dtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface IIdentityUserservice
    {
        public Task<ResultDto<bool>> UpdatePassword(int identityId, string oldpass, string newpass);
        public Task<ResultDto<bool>> UpdateIdentity(int identityId, string Username, string email);
    }
}
