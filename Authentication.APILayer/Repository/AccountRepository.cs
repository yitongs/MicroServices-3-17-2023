using Authentication.APILayer.Data;
using Microsoft.AspNetCore.Identity;

namespace Authentication.APILayer.Repository
{
    public class AccountRepositoryAsync:IAccountRepositoryAsync
    {
        private readonly UserManager<HrmUser> userManager;
        private readonly SignInManager<HrmUser> signInManager;

        public AccountRepositoryAsync(UserManager<HrmUser> userManager, SignInManager<HrmUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            HrmUser user = new HrmUser() { 
            
            FirstName = model.FirstName, LastName = model.LastName, Email = model.Email,
            UserName=model.Email
            };

         return await  userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> LoginAsync(SignInModel signInModel) {

          return await  signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
        }
    }
}
