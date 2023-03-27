using Authentication.APILayer.Data;
using Microsoft.AspNetCore.Identity;

namespace Authentication.APILayer.Repository
{
    public interface IAccountRepositoryAsync
    {

        Task<IdentityResult> SignUpAsync(SignUpModel model);

         Task<SignInResult> LoginAsync(SignInModel signInModel);
    }
}
