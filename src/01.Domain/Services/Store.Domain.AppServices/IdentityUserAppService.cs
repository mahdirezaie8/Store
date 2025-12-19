using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;

namespace Store.Domain.AppServices
{
    public class IdentityUserAppService: IIdentityUserAppService
    {
        private readonly IIdentityUserservice identityUserservice;

        public IdentityUserAppService(IIdentityUserservice IdentityUserservice)
        {
            identityUserservice = IdentityUserservice;
        }
        public async Task<ResultDto<bool>> UpdateIdentity(int identityId, string Username, string email)
        {
            return await identityUserservice.UpdateIdentity(identityId, Username, email);
        }
        public async Task<ResultDto<bool>> UpdatePassword(int identityId, string oldpass, string newpass)
        {
            return await identityUserservice.UpdatePassword(identityId, oldpass, newpass);
        }
    }
}
